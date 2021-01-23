    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        const string kvPair   = @"(?<pair>(?<key>.*?)\s*=\s*(?<value>.*?))";
        const string kvpRegex = "^" + kvPair + "$";
        const string csRegex  = @"^\s*(?<cs>(?:" + kvPair + @"\s*(;\s*|\s*$))+)$";
    
        public static void Main(string[] args)
        {
            const string input = @"Data Source=Instance1;User ID=;Initial Catalog=DB;Provider=SQLOLEDB.1;Integrated Security=SSPI;Auto Translate=False;";
    
            var match = Regex.Match(input, csRegex);
            Console.WriteLine("======\nSuccess: {0}\n======", match.Success);
    
            // 'smart' dictionary from the subcaptures:
            var dict = match.Groups["pair"]
                .Captures
                .Cast<Capture>()
                .Select(cap => Regex.Match(cap.Value, kvpRegex))
                .ToDictionary(submatch => submatch.Groups["key"].Value,
                              submatch => submatch.Groups["value"].Value);
    
            foreach (var kvp in dict)
                Console.WriteLine(kvp);
    
            // Getting just the DB1:
            Console.WriteLine("======\nCatalog: {0}\n======", dict["Initial Catalog"]);
    
            // raw access from csRegex full match:
            foreach (Capture cap in match.Groups["key"].Captures)
                Console.WriteLine("Key: '{0}'", cap.Value);
            foreach (Capture cap in match.Groups["value"].Captures)
                Console.WriteLine("Value: '{0}'", cap.Value);
    
            Console.WriteLine("======\nConnection string: '{0}'", match.Groups["cs"].Value);
        }
    }
