    using System;
    using System.Web.Script.Serialization;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string input = @"[1,2,3,4,'Name\'s(w)','ProductName','2013,6,1,10,00,00','2013,6,1,10,00,00',0]";
                var parsed = new JavaScriptSerializer().Deserialize<object[]>(input);
                foreach (var o in parsed)
                {
                    Console.WriteLine(o.ToString());
                }
                Console.ReadLine();
            }
        }
    }
