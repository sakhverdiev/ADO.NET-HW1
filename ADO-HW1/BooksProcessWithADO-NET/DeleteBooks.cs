using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
 
namespace BooksProcessWithADO_NET
{
    public partial class DeleteBooks : Form
    {
        string connectionString = null; // connection string
        public DeleteBooks()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                try
                {
                    using (var conStr = new SqlConnection(connectionString))
                    {
                        conStr.Open();
                        string query = $"Delete From Books Where Id = @Id";
                        SqlCommand command = new SqlCommand(query, conStr);
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Id", textBox1.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Delete succesfully!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Id verilmeyib!");
        }
    }
}
