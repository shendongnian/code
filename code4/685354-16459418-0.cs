    using System;
    using Newtonsoft.Json.Linq;
    
    namespace testClient
    {
        class Program
        {
            static void Main()
            {
                var myJsonString = "{report: {Id: \"aaakkj98898983\"}}";
                var jo = JObject.Parse(myJsonString);
                var id = jo["report"]["Id"].ToString();
                Console.WriteLine(id);
                Console.Read();
            }
        }
    }   
