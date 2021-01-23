    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private OleDbConnection con =
                new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\test.mdb\";");
    
            private OleDbDataAdapter adapter;
            DataTable table = new DataTable("person"); 
    
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                con.Open();
                ;
                adapter = new OleDbDataAdapter("select ID, p_name, p_age from person", con);
                adapter.Fill(table);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.DeleteCommand = builder.GetDeleteCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.InsertCommand = builder.GetInsertCommand();
                dataGridView1.DataSource = table;
    
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                con.Close();
                con.Dispose();
            }
    
            private void btnDelete_Click(object sender, EventArgs e)
            {
                DataRow[] row = table.Select("p_age = 10");
                if (row.Length > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i].Delete();
                    }
                }
                adapter.Update(table);
            }
    
        }
    }
