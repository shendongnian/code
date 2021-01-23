    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using System.Threading.Tasks; 
    using Microsoft.SqlServer.Management.Smo; 
    using Microsoft.SqlServer.Management.Sdk.Sfc; 
    using Microsoft.SqlServer.Management.Common; 
    using System.Collections.Specialized; 
    using System.IO; 
    using System.Data; 
    using Microsoft.SqlServer.Management; 
    using System.Data.SqlClient;
    namespace GenrateScriptsForDatabase
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var server = new Server(new ServerConnection { ConnectionString = new SqlConnectionStringBuilder { DataSource = @"Your Server Name", UserID="Your User Id",Password="Your Password" }.ToString() });
                server.ConnectionContext.Connect();
                var database = server.Databases["Your Database Name"];
    
                using (FileStream fs = new FileStream(@"H:\database_scripts\Gaurav.sql", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for each (Table table in database.Tables)
                    {
                        if (table.Name == "Your Table Name")
                        {
                            var scripter = new Scripter(server) { Options = { ScriptData = true } };
                            var script = scripter.EnumScript(new SqlSmoObject[] { table });
                            for each (string line in script)
                            {
                              
                                    sw.WriteLine(line);
                                    Console.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
    }
