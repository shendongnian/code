    SqlDatabase database = new SqlDatabase(transMangr.ConnectionString);
    DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "proc_name", useStoredProc);
    
    database.AddInParameter(commandWrapper, "@ProductID", DbType.Int32 );
    database.AddInParameter(commandWrapper, "@ProductDesc", DbType.String);
    ...more parameters...
    
    foreach (var entity in entitties)
    {
    	database.SetParameterValue(commandWrapper, "@ProductID",entity._productID);
    	database.SetParameterValue(commandWrapper, "@ProductDesc",entity._desc);
    	//..more parameters...
    	Utility.ExecuteNonQuery(transMangr, commandWrapper);
    }
