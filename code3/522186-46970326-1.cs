            //Base list is a list of fields, ie a data record
            //Enclosing list is then a list of those records, ie the Result set
            List<List<String>> ResultSet = new List<List<String>>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(qString, connection);
                // Create and execute the DataReader..
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var rec = new List<string>();
                    for (int i = 0; i < reader.FieldCount-1; i++)
                    {                      
                        rec.Add(reader.GetString(i));
                    }
                    ResultSet.Add(rec);
                    
                }
            }
