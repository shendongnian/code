    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    static class Program
    {
        static void Main()
        {
            foreach (var item in ReadFile("my.txt").OrderBy(x => x.Joined))
            {
                Console.WriteLine(item.Names);
            }
        }
        static readonly char[] tab = { '\t' };
        class Foo
        {
            public string Names { get; set; }
            public int Age { get; set; }
            public string Designation { get; set; }
            public DateTime Joined { get; set; }
        }
        static IEnumerable<Foo> ReadFile(string path)
        {
            using (var reader = File.OpenText(path))
            {
                // skip the first line (headers), or exit
                if (reader.ReadLine() == null) yield break;
    
                // read each line
                string line;
                var culture = CultureInfo.InvariantCulture;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(tab);
                    yield return new Foo
                    {
                        Names = parts[0],
                        Age = int.Parse(parts[1], culture),
                        Designation = parts[2],
                        Joined = DateTime.Parse(parts[3], culture)
                    };
                }
            }
        }
    }
