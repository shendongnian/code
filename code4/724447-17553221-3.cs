    void MYSQLInteractionFunction(String myConnectionString)
     {
        String searchQueryString = "SELECT NULL AS ObjectID, page AS location, 'pageSettings' AS type, page AS value, 'pageName' AS contentType, ";
        SqlConnection myConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommand = new SqlCommand(searchQueryString, myConnection);
        myConnection.Open();
        SqlDataReader queryCommandReader = myCommand.ExecuteReader();
        // Create a DataTable object to hold all the data returned by the query.
        DataTable dataTable = new DataTable();
 
        // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
        dataTable.Load(queryCommandReader);
        Int32 rowID = 0; // or iterate on your Rows - depending on what you want
        foreach (DataColumn column in dataTable.Columns)
        {
           myStringList.Add(dataTable.Rows[rowID][column.ColumnName] + " | ");
           rowID++;
         }
         myConnection.Close();
         String[] myStringArray = myStringList.ToArray();
         UnlimitedParameters(myStringArray);
    }
    static void UnlimitedParameters(params string[] values)
    {
        foreach (string strValue in values)
        {
            // Do whatever you want to do with this strValue
         }
     }
