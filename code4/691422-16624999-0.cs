     private static void ShowFields()
     {
         using (SqlConnection connection = new SqlConnection(connectionstring))
         {
             connection.Open();
    
             SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='table1'", connection);
             SqlDataReader reader = command.ExecuteReader();
    
             connection.Close();
    
             int colCount = reader.FieldCount;
    
             while (reader.Read())
             {
                 for (int i = 0; i < colCount; i++)
                 {
                     Console.WriteLine(reader[i]);
                 }
             }
         }
     }
