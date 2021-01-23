    public DataSet GetProject(string projectID)
    {
       DataSet dataTable = new DataSet(); 
       DataAccess dataAccess = new DataAccess();
       OracleCommand commandOb = new OracleCommand();
       strQuery = @"select projectName, managerName
                      from project
                      where projectID = :ProjectID"
    
       cmd.CommandText = strQuery;
       cmd.Parameters.AddWithValue("ProjectID", projectID);
       dataTable = dataAccess.ExecuteDataAdapter(commandOb);
    
       return dataTable;
    }
