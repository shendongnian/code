    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       connection.Open();
       using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
       {
          bulkCopy.DestinationTableName = "destinationTable";
          try
          {
             bulkCopy.WriteToServer(collection.GetData());
          }
          catch (Exception ex)
          {
             Console.WriteLine(ex.Message);
          }
       }
   }
