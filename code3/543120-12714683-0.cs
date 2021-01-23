    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    SqlConnection conn = new SqlConnection(sqlConnectionString);
    Server server = new Server(new ServerConnection(conn));
    server.ConnectionContext.ExecuteNonQuery(script);
