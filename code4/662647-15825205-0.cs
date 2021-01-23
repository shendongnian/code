    private void InsertCustomers(string name,string address,string city,string state)
    {
        using (SqlConnection conn = new SqlConnection(connstr))
                    {
                        conn.Open();
                        StringBuilder sqlStr = new StringBuilder("INSERT into Customers values ( @name, @address, @city, @state)");
                        SqlCommand cmd = new SqlCommand(sqlStr.ToString(), conn);
                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@address", address));
                        cmd.Parameters.Add(new SqlParameter("@city", city));
                        cmd.Parameters.Add(new SqlParameter("@state", state));
                        cmd.ExecuteNonQuery();
        
                    }
        
    }
