      DataSet GetData(String queryString)
    {
    // Retrieve the connection string stored in the Web.config file.
    String connectionString = ConfigurationManager.ConnectionStrings["NorthWindConnectionString"].ConnectionString;      
    DataSet ds = new DataSet();
    try
    {
      // Connect to the database and run the query.
      SqlConnection connection = new SqlConnection(connectionString);        
      SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
      // Fill the DataSet.
      adapter.Fill(ds);
    }
    catch(Exception ex)
    {
      // The connection failed. Display an error message.
      Message.Text = "Unable to connect to the database.";
    }
    return ds;
    }
  
