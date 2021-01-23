    _connection = connections[_connectionName].AcquireConnection(null) as DbConnection;
    
    if (_connection == null)
    {
        ConnectionManager cm = connections[_connectionName];
        Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100 cmParams = cm.InnerObject as Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100;
        _connection = cmParams.GetConnectionForSchema() as OleDbConnection;
    
        if (_connection == null)
        {
            componentEvents.FireError(0, METHOD_NAME, "The connection is not a valid ADO.NET or OLEDB connection", "", -1);
            return DTSExecResult.Failure;
        }
    }
