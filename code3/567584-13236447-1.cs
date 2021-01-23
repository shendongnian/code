    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    
    namespace SqlExporter
    {
    class Program
    {
    static void Main(string[] args)
    {
        var server = new Server(new ServerConnection {ConnectionString = new SqlConnectionStringBuilder {DataSource = @"LOCALHOST\SQLEXPRESS", IntegratedSecurity = true}.ToString()});
        server.ConnectionContext.Connect();
        var database = server.Databases["MyDatabase"];
        var output = new StringBuilder();
    
        foreach (Table table in database.Tables)
        {
            var scripter = new Scripter(server) {Options = {ScriptData = true}};
            var script = scripter.EnumScript(new SqlSmoObject[] {table});
            foreach (var line in script)
                output.AppendLine(line);
        }
        File.WriteAllText(@"D:\MyDatabase.sql", output.ToString());
    }
    }
    }
