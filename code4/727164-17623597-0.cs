    using (OleDbConnection CSVConnection = new OleDbConnection(CSVConnectionString))
    {
         try
         {
             CSVConnection.Open();
             string strInsertCommand = @"INSERT INTO " + strFilename + @" (CustomerID, CustomerName, Country) VALUES (@custid, @name, @country)";
             OleDbCommand InsertCommanmd = CSVConnection.CreateCommand();
             InsertCommanmd.CommandText = strInsertCommand;
                        
             foreach ( var item in List<T> )
             {
                 InsertCommanmd.Parameters.Clear();
                 InsertCommanmd.Parameters.AddWithValue("@custid", item.prop1);
                 InsertCommanmd.Parameters.AddWithValue("@name", item.prop2);
                 InsertCommanmd.Parameters.AddWithValue("@country", item.prop3);
                 InsertCommanmd.ExecuteNonQuery();
             }
         }
         catch (Exception e)
         {
             Console.WriteLine("CSV Database Err: " + e.Message);
         }
         finally
         {
              if (!CSVConnection.State.Equals(ConnectionState.Closed))
                  CSVConnection.Close();
         }
    }
