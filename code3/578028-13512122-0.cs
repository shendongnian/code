    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DeserializeObject();
                Console.ReadKey();
            }
    
            private static async void DeserializeObject()
            {
                using (var reader = new StreamReader("TextFile1.txt"))
                {
                    var jsonSerializerSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto};
                    var value = await reader.ReadToEndAsync();
                    var result = JsonConvert.DeserializeObject<RootObject>(value, jsonSerializerSettings);
                }
            }
        }
    
        public class RootObject
        {
            public bool success { get; set; }
            public Dictionary<string, List<Child12>> deal { get; set; }
        }
    
        public class Child12
        {
            public string scan_count { get; set; }
            public string id { get; set; }
            public string merchant_id { get; set; }
            public string company_id { get; set; }
            public string points_to_earn { get; set; }
            public string equivalent_points { get; set; }
            public string description { get; set; }
            public string deal_city { get; set; }
            public string price { get; set; }
            public string guidelines { get; set; }
            public string business_name { get; set; }
            public string b_type { get; set; }
            public string b_image { get; set; }
    
        }
    }
