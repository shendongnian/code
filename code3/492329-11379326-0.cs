    DbConnection connection = connections[_connectionName].AcquireConnection(null) as DbConnection;
    
    ConnectionManager cm = Dts.Connections["oledb"];
    Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100 cmParams = cm.InnerObject as Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100;
    OleDbConnection conn = cmParams.GetConnectionForSchema() as OleDbConnection;
    
    if (connection == null)
    {
        componentEvents.FireError(0, METHOD_NAME, "The connection is not a valid ADO.NET connection", "", -1);
        return DTSExecResult.Failure;
    }
    
