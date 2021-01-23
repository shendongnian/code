    cmm.CommandText = "SaveCards";
    //cmm.Connection.Open(); You should open the connection after assigning it
    cmm.Connection = Linq.Connection;
    cmm.CommandType = CommandType.StoredProcedure;
    cmm.Connection.Open(); //Open it here
    
    IDataReader rdr = cmm.ExecuteReader();
