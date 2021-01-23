    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Data.SqlClient;
[...]
    private void Execute(object sender, EventArgs e)
    {
        string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
    
        FileInfo file = new FileInfo(@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");
    
        string script = file.OpenText().ReadToEnd();
    
        SqlConnection conn = new SqlConnection(sqlConnectionString);
    
        Server server = new Server(new ServerConnection(conn));
    
        server.ConnectionContext.ExecuteNonQuery(script);
        file.OpenText().Close();    
    }
