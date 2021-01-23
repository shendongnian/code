    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            JObject parsed = JObject.Parse(File.ReadAllText("test.json"));
            IDictionary<string, JToken> rates = (JObject) parsed["rates"];
            // Explicit typing just for "proof" here
            Dictionary<string, decimal> dictionary =
                rates.ToDictionary(pair => pair.Key,
                                   pair => (decimal) pair.Value);
            Console.WriteLine(dictionary["ALL"]);
        }
    }
