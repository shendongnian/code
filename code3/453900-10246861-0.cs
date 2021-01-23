    using (OdbcConnection connection = 
                   new OdbcConnection(connectionString))
        {
    		string queryString = "SELECT * FROM Members";
    		OdbcDataAdapter adapter = 
                new OdbcDataAdapter(queryString, connection);
    
            // Open the connection and fill the DataSet.
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
