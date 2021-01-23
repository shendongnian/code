    public void UpdateAllFromDgv(DataGridView dataGridView1)
            {
                string query = "Update List set ColumnName1=@Value1" +
                    ",ColumnName2=@Value2" +
                    ",ColumnName3=@Value3" +
                    ",ColumnName4=@Value4" +
                    ",ColumnName5=@Value5" +
                    ",ColumnName6=@Value6  where ColumnName0=@Value0";
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        using (MySqlConnection con = new MySqlConnection(ConnectionString))
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@Value0", row.Cells[0].Value);
                                cmd.Parameters.AddWithValue("@Value1", row.Cells[1].Value);
                                cmd.Parameters.AddWithValue("@Value2", row.Cells[2].Value);
                                cmd.Parameters.AddWithValue("@Value3", row.Cells[3].Value);
                                cmd.Parameters.AddWithValue("@Value4", row.Cells[4].Value);
                                cmd.Parameters.AddWithValue("@Value5", row.Cells[5].Value);
                                cmd.Parameters.AddWithValue("@Value6", row.Cells[6].Value);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                dataGridView1.ResetBindings();
                                con.Close();
                            }
                        }
    
                    }
                }
                catch (MySqlException MsE)
                {
                    MessageBox.Show(MsE.Message.ToString());
                   
                }
            }
