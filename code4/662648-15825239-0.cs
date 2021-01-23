    using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    StringBuilder sqlStr = new StringBuilder("INSERT into Customers values ( @name, @address, @city, @state)");
                    SqlCommand cmd = new SqlCommand(sqlStr.ToString(), conn);
                    cmd.Parameters.Add(new SqlParameter("name", "John Smith"));
                    cmd.Parameters.Add(new SqlParameter("address", "123 Main St."));
                    cmd.Parameters.Add(new SqlParameter("city", "Detroit"));
                    cmd.Parameters.Add(new SqlParameter("state", "Michigan"));
                    int rowsAffected = cmd.ExecuteNonQuery();
    
                    cmd.Parameters["name"].Value = "William Jones";
                    cmd.Parameters["address"].Value = "500 Blanchard Ave";
                    cmd.Parameters["city"].Value = "Chicago";
                    cmd.Parameters["state"].Value = "Illinois";
                    rowsAffected = cmd.ExecuteNonQuery();
                }
