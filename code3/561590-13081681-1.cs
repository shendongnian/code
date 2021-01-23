    // Create a String to hold the query.
    string query = "SELECT * FROM testing";
     
    // Create a SqlCommand object and pass the constructor the connection string and the query string.
    SqlCommand cmd = new SqlCommand(query, conn);
     
    // Use the above SqlCommand object to create a SqlDataReader object.
    SqlDataReader rdr = queryCommand.ExecuteReader();
     
    // Create a DataTable object to hold all the data returned by the query.
    DataTable dataTable = new DataTable();
     
    // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
    dataTable.Load(rdr);
