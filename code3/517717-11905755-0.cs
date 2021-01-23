       using (reader = server.ExecuteReader(CommandType.Text, TopIDQuery, paramet))
       {
           while (reader.Read())
           {
               var column = reader.GetOrdinal("TopID");
    
               if (!reader.IsDBNull(column))
                  topID = Convert.ToInt32(reader[column]);
               }
           }
       }
    
    Or, compare against DBNull.Value:
    
       var value = reader["TopID"];
    
       if (value != DBNull.Value)
       {
           topID = Convert.ToInt32(value);
       }
