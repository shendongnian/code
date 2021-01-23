            using (SqlConnection connection = new SqlConnection(connString))
            {
              string sql = "SELECT * FROM users WHERE name LIKE @NameSearch";
                try
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, connection))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            da.SelectCommand.Parameters.AddWithValue("@NameSearch", txt_Name.Text+"%");
                                 
                                DataTable dt = new DataTable();
                                da.Fill(dt);                                                                   
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                  MessageBox.Show(ex.Message);
                }
            }
