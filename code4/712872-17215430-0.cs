    using (var connection = new SqlConnection(conString))
    {
         var command = new SqlCommand(..., connection);
         var apapter - new SqlDataAdapter(command);
         var ds = new DataSet();
         connection.Open();
         adapter.Fill(ds);
         if (ds.Tables.Count >= 1)  <<--  Set a breakpoint here and inspect the dataset
         {
            ...
         }
    }
