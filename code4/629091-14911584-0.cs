    private void button2_Click(object sender, EventArgs e)
            {
                using (SqlCeConnection CONN = new SqlCeConnection("Data Source=LocalDBSSCompactEdition.sdf;"))
                {
                    CONN.Open();
                    SqlCeCommand comm = CONN.CreateCommand();                
                    int i = dataGridView2.Rows.Count-1;
                    
                        String queryString = @"INSERT INTO tblEmployee (FirstName, LastName, DeptID) VALUES ('"                    
                        + dataGridView2.Rows[5].Cells["FirstName"].Value + "','"
                        + dataGridView2.Rows[5].Cells["LastName"].Value + "',"
                         + dataGridView2.Rows[5].Cells["DeptID"].Value + ");";
                        comm.CommandText = queryString;
                        comm.ExecuteNonQuery();
                        CONN.Close();    
                }
            }
