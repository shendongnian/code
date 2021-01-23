    FirebirdSql.Data.FirebirdClient.FbTransaction fbt = fbc.BeginTransaction(); // object fbc is your FirebirdSql.Data.FirebirdClient.FbConnection
    
    FirebirdSql.Data.Isql.FbBatchExecution fbe = new FirebirdSql.Data.Isql.FbBatchExecution(fbc);
    fbe.SqlStatements.Add(dropAllForeignKeysSql); // Your string here
    
    fbe.Execute(true);
    
    fbt.Commit();
