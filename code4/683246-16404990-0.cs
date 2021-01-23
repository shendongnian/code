    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            /// <remarks><c>true</c> in returned dictionary key are groups over <paramref name="maxGroupSize"/></remarks>
            public static Dictionary<bool,Dictionary<string, List<string>>> Split(int maxGroupSize, int keySize, IEnumerable<string> items)
            {
                var smallItems = from item in items
                                 where item.Length < keySize
                                 select item;
                var largeItems = from item in items
                                 where keySize < item.Length
                                 select item;
                var largeItemsq = (from item in largeItems
                                   let key = item.Substring(0, keySize)
                                   group item by key into x
                                   select new { Key = x.Key, Items = x.ToList() } into aGrouping
                                   group aGrouping by aGrouping.Items.Count() > maxGroupSize into x2
                                   select x2).ToDictionary(a => a.Key, a => a.ToDictionary(a_ => a_.Key, a_ => a_.Items));
                if (smallItems.Any())
                {
                    var smallestLength = items.Aggregate(int.MaxValue, (acc, item) => Math.Min(acc, item.Length));
                    var smallItemsq = (from item in smallItems
                                       let key = item.Substring(0, smallestLength)
                                       group item by key into x
                                       select new { Key = x.Key, Items = x.ToList() } into aGrouping
                                       group aGrouping by aGrouping.Items.Count() > maxGroupSize into x2
                                       select x2).ToDictionary(a => a.Key, a => a.ToDictionary(a_ => a_.Key, a_ => a_.Items));
                    return Combine(smallItemsq, largeItemsq);
                }
                return largeItemsq;
            }
            static Dictionary<bool, Dictionary<string,List<string>>> Combine(Dictionary<bool, Dictionary<string,List<string>>> a, Dictionary<bool, Dictionary<string,List<string>>> b) {
                var x = new Dictionary<bool,Dictionary<string,List<string>>> {
                    { true, null },
                    { false, null }
                };
                foreach(var condition in new bool[] { true, false }) {
                    var hasA = a.ContainsKey(condition);
                    var hasB = b.ContainsKey(condition);
                    x[condition] = hasA && hasB ? a[condition].Concat(b[condition]).ToDictionary(c => c.Key, c => c.Value)
                        : hasA ? a[condition]
                        : hasB ? b[condition]
                        : new Dictionary<string, List<string>>();
                }
                return x;
            }
            public static Dictionary<string, List<string>> Group(int maxGroupSize, IEnumerable<string> items, int keySize)
            {
                var toReturn = new Dictionary<string, List<string>>();
                var both = Split(maxGroupSize, keySize, items);
                if (both.ContainsKey(false))
                    foreach (var key in both[false].Keys)
                        toReturn.Add(key, both[false][key]);
                if (both.ContainsKey(true))
                {
                    var keySize_ = keySize + 1;
                    var xs = from needsFix in both[true]
                             select needsFix;
                    foreach (var x in xs)
                    {
                        var fixedGroup = Group(maxGroupSize, x.Value, keySize_);
                        toReturn = toReturn.Concat(fixedGroup).ToDictionary(a => a.Key, a => a.Value);
                    }
                }
                return toReturn;
            }
            static Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            const string allowedChars = "aaabbbbccccc"; // "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            static readonly int maxAllowed = allowedChars.Length - 1;
            static IEnumerable<string> GenerateText()
            {
                var list = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    var stringLength = rand.Next(3,25);
                    var chars = new List<char>(stringLength);
                    for (int j = stringLength; j > 0; j--)
                        chars.Add(allowedChars[rand.Next(0, maxAllowed)]);
                    var newString = chars.Aggregate(new StringBuilder(), (acc, item) => acc.Append(item)).ToString();
                    list.Add(newString);
                }
                return list;
            }
            static void Main(string[] args)
            {
                // runs 1000 times over autogenerated groups of sample text.
                for (int i = 0; i < 1000; i++)
                {
                    var s = GenerateText();
                    Go(s);
                }
                Console.WriteLine();
                Console.WriteLine("DONE");
                Console.ReadLine();
            }
            static void Go(IEnumerable<string> items)
            {
                var dict = Group(3, items, 1);
                foreach (var key in dict.Keys)
                {
                    Console.WriteLine(key);
                    foreach (var item in dict[key])
                        Console.WriteLine("\t{0}", item);
                }
            }
        }
    }
