    using System;
    using Intuit.QuickBase.Client;
    namespace MyProgram.QB.Interaction
    {
        class MyApplication
        {
            static void Main(string[] args)
            {
                var client = QuickBase.Client.QuickBase.Login("your_QB_username", "your_QB_password");
                var application = client.Connect("your_app_dbid", "your_app_token");
                var table = application.GetTable("your_table_dbid");
                table.Query();
                foreach(var record in table.Records)
                {
                   Console.WriteLine(record["your_column_heading"]);
                }
                client.Logout();
            }
        }
    }
