    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var foo = MySqlHelper.ExecuteDataRow("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;", "select * from foo");
                Console.WriteLine(foo["Column"]);
            }
        }
    }
