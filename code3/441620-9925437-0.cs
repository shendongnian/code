    oraConn = new OracleConnection("CONNECTION STRING");
    oraConn.Open();
    //Command with transaction
    OracleCommand oraCom = oraConn.CreateCommand();
    oraCom.CommandText = "INSERT QUERY";
    oraCom.Transaction = oraCom.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
    //Execute
    if (oraCom.Connection.State == ConnectionState.Closed)
    {
          oraCom.Connection.Open();
    }
    
    oraCom.ExecuteNonQuery();
    //Commit / Rollback
    oraCom.Transaction.Commit(); // or oraCom.Transaction.Rollback();
