    string tableName ="" ; // Variable to stroe the table names
    string connectionString = ""; //Your connectionstring
    // get records from the table
    string commandString =""; //Your query
    // create the data set command object
    // and the DataSet
    SqlDataAdapter DataAdapter =new SqlDataAdapter(commandString, connectionString);
    DataSet DataSet = new DataSet( );
    // fill the DataSet object
    DataAdapter.Fill(DataSet, "Customers");
    // Get the one table from the DataSet
    DataTable dataTable = DataSet.Tables[0];
    // for each row in the table, display the info
    foreach (DataRow dataRow in dataTable.Rows)
     {
      tableName = dataRow[0].tostring();
      //...
      }
