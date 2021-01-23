    private void delete_record()
        {
            
             if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                try
                {
                    //am taking connection string using a class called "sqlconnection_imventory()"
                    SqlConnection conn = Connection.sqlconnection_imventory();
                    //Cell[0] is my button column & Cell[1] is SID coumn
                    string a = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string sql = "DELETE FROM grades WHERE SID='" + a + "'";
                    conn.Open();
                    SqlCommand delcmd = new SqlCommand(sql, conn);
                    delcmd.Connection = conn;
                    delcmd.ExecuteNonQuery();
                    conn.Close();
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    MessageBox.Show("deleted");
                }
                catch (Exception)
                {
                    throw;
                } 
            }
        }
