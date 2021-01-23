    OracleConnection connection = OracleConnectionOpen("csEmailManagement");
    OracleCommand command = new OracleCommand();
    // Start query string
    string query = "INSERT ALL ";
    for (int i = 0; i < emailMessageList.Length; i++)
    {
        query = string.Format("{0} INTO YS_ES_TO(EMAILID,EMAILTO) VALUES (:{1}, :{2})",
                              query,
                              "pEMAILID_"+i,
                              "pEMAILTO_"+i);
        command.Parameters.Add("pEMAILID_"+i, 
                               OracleDbType.Int32, 
                               emailId, 
                               ParameterDirection.Input);
        command.Parameters.Add("pEMAILTO_"+i, 
                               OracleDbType.Varchar2, 
                               emailMessageList[i], 
                               ParameterDirection.Input);
    } 
    command.CommandText = query;
    command.Connection = connection;
