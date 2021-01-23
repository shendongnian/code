    private void button2_Click(object sender, EventArgs e)
    {
                SqlConnection myConnection = new SqlConnection("Data Source=MyServerName\\InstanceName;Initial Catalog="+ comboBox1.Text + ";Integrated Security=SSPI;");
                    string sqlQuery = @"SELECT * from " + comboBox2.Text;
                    SqlCommand cmd = new SqlCommand(sqlQuery, myConnection);
    
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = new BindingSource(table, null);
                    dataGridView1.DataBind();
                    myConnection.Close();
    }
