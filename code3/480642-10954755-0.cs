    var cmd = new OracleCommand();
    cmd.Connection = conn;		
    cmd.CommandType = CommandType.Text; 		
    cmd.CommandText = "INSERT INTO Table (name, fromDate, toDate)VALUES(:nameVal, :fromVal, :toVal)";
    cmd.Parameters.Add(new OracleParameter(":fromVal", OracleType.DateTime)).Value = fromDateVal;
    cmd.Parameters.Add(new OracleParameter(":toVal", OracleType.DateTime)).Value = toDateVal;
    cmd.ExecuteNonQuery();
    
    //close the connection after done.... release the resources
