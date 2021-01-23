    //alter parameter data type in stored procedure if parameter is not  varchar
    public static void AlterSPParamInfo (string SPName,string parameterName,string connectionStringName)
    {
        SqlConnection vSqlConnection = CreateSqlConnectionStr(connectionStringName);
        using(vSqlConnection)
            {
                ServerConnection vConnection = new ServerConnection(vSqlConnection);
                Server vServer = new Server(vConnection);
                Database vDatabase = vServer.Databases["HrSys"];
                var vTables = vDatabase.Tables;
                StoredProcedure sp = vDatabase.StoredProcedures[SPName];
                if(sp != null)
                {
                    StoredProcedureParameter spParameter = sp.Parameters[parameterName];
                    if(spParameter!=null)
                    {
                        if(!spParameter.DataType.Equals(DataType.VarChar(50)))
                        {
                            spParameter.DataType = DataType.VarChar(50);
                            sp.QuotedIdentifierStatus = true;
                            try
                            {
                                sp.TextMode = false;
                                sp.Alter( );
                            }
                            catch(SqlServerManagementException ex)
                            {
                                //other code
                            }
                        }
                    }         
     }
