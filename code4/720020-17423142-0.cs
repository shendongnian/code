    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = new [] {
                    "EUR5-002,EUR10-000,EUR20-001,EUR50-001,EUR100-001,EUR200-000,EUR500-000", 
                    "EUR5-000,EUR10-000,EUR20-002,EUR50-001,EUR100-001,EUR200-000,EUR500-000", 
                    "EUR5-001,EUR10-001,EUR20-002,EUR50-001,EUR100-002,EUR200-003,EUR500-000"
                };
    
                var results = new Dictionary<string, int>();
    
                foreach (var line in data)
                {
                    var entries = line.Split(',');
                    foreach (var entry in entries)
                    {
                        var parts = entry.Split('-');
                        string key = parts[0];
                        if (!results.ContainsKey(key))
                        {
                            results[key] = 0;
                        }
    
                        results[key] += int.Parse(parts[1]);
                    }
                }
    
                foreach (var result in results)
                {
                    Console.WriteLine(result.Key + "-" + result.Value.ToString("000"));
                }
    
                Console.ReadLine();
            }
        }
    }
