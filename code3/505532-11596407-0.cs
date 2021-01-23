    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            var regex = new Regex(@"^(?:\d+)\s+(?<ip>[\d.]+)\s+(?<ping>\d+)\s+(?<id>\d+)\s+(?<name>.*)$");
            var query = File.ReadLines("data.txt")
                            .Skip(1)
                            .Select(line => regex.Match(line))
                            .Select(match => new {
                                        IP = match.Groups["ip"].Value,
                                        Ping = match.Groups["ping"].Value,
                                        Id = match.Groups["id"].Value,
                                        Name = match.Groups["name"].Value
                                    });
            
            foreach (var entry in query)
            {
                Console.WriteLine(entry);
            }
        }
    }
