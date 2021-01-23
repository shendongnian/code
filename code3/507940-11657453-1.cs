    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.SqlEnum;
    using System.Configuration;
    using System.Collections.Specialized;
    
    namespace SmoTest {
        class Program {
            static void Main(string[] args) {
                Server server = new Server("XXX");
                Database database = new Database();
                database = server.Databases["YYY"];
                Table table = database.Tables["ZZZ", @"PPP"];
    
                StringCollection result = table.Script();
    
                var script = "";
                foreach (var line in result) {
                    script += line;
                }
    
                System.IO.StreamWriter fs = System.IO.File.CreateText(@"QQQ");
                fs.Write(script);
                fs.Close();
            }
        }
    }
