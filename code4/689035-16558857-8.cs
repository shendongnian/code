    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "[{'Response':'OK','UUID':'89172'},{'Response':'OK','UUID':'10304'}]";
            var items= JsonConvert.DeserializeObject<List<MyClass>>(jsonString);
            foreach (var item in items)
            {
                Console.WriteLine("UUUID: "+item.UUID);
                Console.WriteLine("Response: " + item.Response);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    public class MyClass
     {
        public string Response { get; set; }
        public string UUID { get; set; }
     }
    }
