            using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using Hypertable;
     namespace HypertableTest1
     {
    class Program
    {
        static void Main(string[] args)
        {
            //Hyper	net.tcp://host[:port]	Native Hypertable client protocol
            //Thrift	net.tcp://host[:port]	Hypertable Thrift API
            //SQLite	file://[drive][/path]/filename	Embedded key-value store, based on SQLite
            //Hamster	file://[drive][/path]/filename	Embedded key-value store, based on hamsterdb
            var connectionString = "Provider=Hyper;Uri=net.tcp://localhost";
            
            using (var context = Context.Create(connectionString))
            using (var client = context.CreateClient())
            {
                // use the client
                //client.CreateNamespace("CSharp");
                
                
                if (!client.NamespaceExists("/CSharp"))
                    client.CreateNamespace("/CSharp");
                INamespace csNamespace = client.OpenNamespace("CSharp");    
                csNamespace.CreateTable("MyFirstTable", "");
                IList<Cell> c = csNamespace.Query("");
                
                
            }
            Console.ReadLine();
        }
    }
}
