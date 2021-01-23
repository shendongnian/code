            DataSet ReturnValue = new DataSet();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase(ConnectionStringName);
            try
            {
                ReturnValue = db.ExecuteDataSet(StoredProcName, ParameterValues);
            }
            catch (Exception ex)
            {
                // a bunch of code for exception handling removed            
            }
    
    
            return ReturnValue;
     }
