     protected System.Data.SqlClient.SqlConnectionStringBuilder m_ConnectionString;
            public System.Data.Common.DbProviderFactory GetFactory()
            {
                System.Data.Common.DbProviderFactory providerFactory = null;
                providerFactory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
                return providerFactory;
            } // End Function GetFactory
    
    
    
     public System.Data.IDbConnection GetConnection()
            {
                System.Data.SqlClient.SqlConnection sqlc = new System.Data.SqlClient.SqlConnection("ConnectionString");
    
                return sqlc;
            } // End Function GetConnection
    public System.Data.IDbConnection GetConnection(string strInitialCatalog)
            {
                if (string.IsNullOrEmpty(strInitialCatalog))
                {
                    return GetConnection();
                }
    
    
    
    
    
    
    
    
                System.Data.SqlClient.SqlConnection sqlc = null;
    
    
    
    
                lock (this.m_ConnectionString)
                {
                    string strOrigInitialCatalog = this.m_ConnectionString.InitialCatalog;
                    this.m_ConnectionString.InitialCatalog = strInitialCatalog;
                    sqlc = new System.Data.SqlClient.SqlConnection(this.m_ConnectionString.ConnectionString);
                    this.m_ConnectionString.InitialCatalog = strOrigInitialCatalog;
                    strOrigInitialCatalog = null;
                }
    
    
    
    
                return sqlc;
            }
    public System.Data.DataTable GetDataTable(System.Data.IDbCommand cmd, string strDb)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
    
                using (System.Data.IDbConnection idbc = GetConnection(strDb))
                {
    
                    lock (idbc)
                    {
    
                        lock (cmd)
                        {
    
                            try
                            {
                                cmd.Connection = idbc;
    
                                using (System.Data.Common.DbDataAdapter daQueryTable = this.m_providerFactory.CreateDataAdapter())
                                {
                                    daQueryTable.SelectCommand = (System.Data.Common.DbCommand)cmd;
                                    daQueryTable.Fill(dt);
                                } // End Using daQueryTable
    
    
    
                            } // End Try
                            catch (System.Data.Common.DbException ex)
                            {
                                //COR.Debug.MsgBox("Exception executing ExecuteInTransaction: " + ex.Message);
                                Log("cMS_SQL.GetDataTable(System.Data.IDbCommand cmd)", ex, cmd.CommandText);
                            }// End Catch
                            finally
                            {
                                if (idbc != null && idbc.State != System.Data.ConnectionState.Closed)
                                    idbc.Close();
                            } // End Finally
    
                        } // End lock cmd
    
                    } // End lock idbc
    
                } // End Using idbc
    
                return dt;
            } // End Function GetDataTable
    public override System.Data.DataTable GetDataTable(string strSQL, string strInitialCatalog)
    {
        System.Data.DataTable dt = null;
        using (System.Data.IDbCommand cmd = this.CreateCommand(strSQL))
        {
            dt = GetDataTable(cmd, strInitialCatalog);
        } // End Using cmd
        return dt;
    } // End Function GetDataTable
