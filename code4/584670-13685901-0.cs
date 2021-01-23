    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;
    class Program
    {
        public class EntryLine
        {
            public int I { get; set; }
            public string LineStart { get; set; }
            public string Letters { get; set; }
            public int TVolume { get; set; }
            public long TPrice { get; set; }
            public double MVolume { get; set; }
            public string Currency { get; set; }
        }
        static void Main(string[] args)
        {
            List<EntryLine> myList = new List<EntryLine>();
            int i = 1;
            using (StreamReader reader = new StreamReader("file.dat"))
            {
                string line;
                var locations = new Dictionary<string, int[]>() {
                {"210", new [] {405, 4, 128, 12, 141, 12, 247, 15, 121, 3}}, 
                {"310", new [] {321, 4, 112, 12, 125, 12, 230, 15, 105, 3}}, 
                {"410", new [] {477, 4, 112, 12, 125, 12, 360, 15, 105, 3}} 
            };
                while ((line = reader.ReadLine()) != null)
                {
                    var lineStart = line.Substring(0, 3);
                    if (lineStart == "210" || lineStart == "310" || lineStart == "410")
                    {
                        var currentLocations = locations[lineStart];
                        var letters = line.Substring(currentLocations[0], currentLocations[1]);
                        var tvolume =
                            int.Parse(line.Substring(currentLocations[2], currentLocations[3])) +
                            int.Parse(line.Substring(currentLocations[4], currentLocations[5]));
                        var tprice = long.Parse(line.Substring(currentLocations[6], currentLocations[7]));
                        var mvolume = tprice * tvolume * 0.01 * 0.0000001;
                        var currency = line.Substring(currentLocations[8], currentLocations[9]);
                        myList.Add(new EntryLine()
                        {
                            I = i,
                            LineStart = lineStart,
                            Letters = letters,
                            TVolume = tvolume,
                            TPrice = tprice,
                            MVolume = mvolume,
                            Currency = currency
                        });
                        i = i + 1;
                    }
                }
                var x = myList.GroupBy(g => new { g.Letters, g.Currency })
                    .Select(a => new { a.Key.Letters, a.Key.Currency, TSum = a.Sum(s => s.TVolume), MSum = a.Sum(s => s.MVolume) });
                foreach (var item in x)
                {
                    Console.WriteLine("{0} currency: {1} tvolume: {2} mVolume: {3}", item.Letters, item.Currency, item.TSum, item.MSum);
                }
            }
        }
    }
