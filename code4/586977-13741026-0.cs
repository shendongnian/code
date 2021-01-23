    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string json = "[{\"id\":1,\"width\":100,\"sortable\":true}, {\"id\":\"Change\",\"width\":100,\"sortable\":true}]";
            JArray array = JsonConvert.DeserializeObject(json) as JArray;
            if (array != null)
            {
                foreach (JObject jObj in array)
                    Console.WriteLine("{0,10} | {1,10} | {2,10}", jObj["id"], jObj["width"], jObj["sortable"]);
            }
            Console.ReadKey(true);
        }
    }
