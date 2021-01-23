    Server srvMgmtServer = default(Server);
    srvMgmtServer = new Server("<sqlserver location>");
    ServerConnection srvConn = default(ServerConnection);
    srvConn = srvMgmtServer.ConnectionContext;
    srvConn.LoginSecure = true;
    // Assuming Database name is 'Northwind'
    Database sourceDatabase = srvMgmtServer.Databases["Northwind"];
    // Assuming Table name is 'Orders'
    if (sourceDatabase.Tables.Contains("Orders", "dbo"))
        MessageBox.Show("Tbl Exists");
    else
        MessageBox.Show("Tbl does exists");
