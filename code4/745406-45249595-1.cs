    private void Employee_Report_Load(object sender, EventArgs e)
    {
            var table = new DataTable();
            var connection = "ConnectionString";
            using (var con = new SqlConnection { ConnectionString = connection })
            {
                using (var command = new SqlCommand { Connection = con })
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    
                    try
                    {
                        command.CommandText = @"SELECT * FROM tblEmployee";
                        table.Load(command.ExecuteReader());
                        
                        bindingSource1.DataSource = table;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.DataSource = bindingSource1;
                        
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " sql query error.");
                    }
                }
            }
     }
