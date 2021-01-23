     public void ExecuteStoredProcReturnDataReader(string sQueryName, out IDataReader dr, List<DBParam> oParams =null)
        {
            
            try
            {
                dbHelper DBProvider = new dbHelper();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                oCmd = DBProvider.CreateCommand(sQueryName, conn);
                if (oParams !=null)
                DBProvider.CreateParameters(oParams, ref oCmd);
                
                dr = oCmd.ExecuteReader();
                
            }
            catch (Exception e)
            {
                rethrow = DataAccessExceptionHandler.HandleException(ref e);
                if (rethrow)
                {
                    throw e;
                }
                dr = null;  
            }
        }
