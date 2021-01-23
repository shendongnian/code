    List<Customer> custList= new List<Customer>();
    string connString="yourConnectionStringHere";
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID,NAME From Customer";           
    
            using (var reader = cmd.ExecuteReader())
            {
               if (reader.HasRows)
               {  
                 while (reader.Read())
                 {
                   var cust= new Customer();
    
                        if (!reader.IsDBNull( reader.GetOrdinal("ID")))
                            cust.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        if (!reader.IsDBNull( reader.GetOrdinal("Name")))
                            cust.Name = reader.GetString(reader.GetOrdinal("Name"));
                        custList.Add(cust);
                 }
               }
            }
        }
    }
