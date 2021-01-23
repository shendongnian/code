    var strSQL = @"UPDATE UserLogin 
                   SET    UserPassword= ?
                   WHERE  UserId= ?";
    
    using (var myConnection = new OleDbConnection(connectionstring)) 
    using (var objOleDbCommand = new OleDbCommand(strSQL, myConnection)) {
   
        // Parameter used for the SET statement declared before the parameter for the WHERE
        // clause since this parameter is used before that one in the SQL statement.
        objOleDbCommand.Parameters.AddWithValue("@paramUserPassword", "ooo");
        objOleDbCommand.Parameters.AddWithValue("@paramUserId", "1");
    
        myConnection.Open();
        objOleDbCommand.ExecuteNonQuery();
    }
