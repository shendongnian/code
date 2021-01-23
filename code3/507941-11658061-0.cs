    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.SqlEnum;
    using Microsoft.SqlServer.Management.Smo.CoreEnum;
    using System.Configuration;
    using System.Collections.Specialized;
    
    namespace SmoTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Server srv = new Server();
    
                // really you would get these from config or elsewhere:
                srv.ConnectionContext.Login = "foo";
                srv.ConnectionContext.Password = "bar";
                srv.ConnectionContext.ServerInstance = "ServerName";
                string dbName = "DatabaseName";
                
                Database db = new Database();
                db = srv.Databases[dbName];
                
                StringBuilder sb = new StringBuilder();
    
                foreach(Table tbl in db.Tables)
                {
                    ScriptingOptions options = new ScriptingOptions();
                    options.ClusteredIndexes = true;
                    options.Default = true;
                    options.DriAll = true;
                    options.Indexes = true;
                    options.IncludeHeaders = true;
    
                    StringCollection coll = tbl.Script(options);
                    foreach (string str in coll)
                    {
                        sb.Append(str);
                        sb.Append(Environment.NewLine);
                    }
                }
                System.IO.StreamWriter fs = System.IO.File.CreateText("c:\\temp\\output.txt");
                fs.Write(sb.ToString());
                fs.Close();
            }
        }
    }
