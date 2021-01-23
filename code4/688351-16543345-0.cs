    using (SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=rex;Initial Catalog=PersonalDetails;Integrated Security=True"))
    {
           con.Open();
           for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
           {
                string insertData = "UPDATE Test SET AvailableQty = @Qty Where ItemCode = @ItemCode";
                SqlCommand cmd = new SqlCommand(insertData, con);
                cmd.Parameters.AddWithValue("@ItemCode", dataGridView2.Rows[i].Cells[0].Value ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Qty", dataGridView2.Rows[i].Cells[4].Value ?? DBNull.Value);
    
                cmd.ExecuteNonQuery();
    
            }
    }
