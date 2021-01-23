    FileInfo file = new FileInfo("upgradeDatabase.sql");
    string script = file.OpenText().ReadToEnd();
    SqlConnection conn = new SqlConnection(sqlConnectionString);
    Server server = new Server(new ServerConnection(conn));
    server.ConnectionContext.ExecuteNonQuery(script);
