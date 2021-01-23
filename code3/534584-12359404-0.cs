            SqlCommand command = new SqlCommand(comm, conn);
            using (var reader = command.ExecuteQuery()) 
            {
                if (reader.Read())
                {
                    //logic
                    var userName = reader.GetString(0);
                    var password = reader.GetString(1);
                    // etc
                }
            }
