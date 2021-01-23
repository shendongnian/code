    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var parts = new SortedDictionary<string, CarPart>(); // Key is a string.
                var part = new CarPart{PartNumber = "NumberOne", PartName = "NameOne", UnitPrice = 100.0m};
                parts.Add(part.PartNumber, part);
                part = new CarPart{PartNumber = "NumberTwo", PartName = "NameTwo", UnitPrice = 100.0m};
                parts.Add(part.PartNumber, part);
                part = new CarPart{PartNumber = "NumberThree", PartName = "NameThree", UnitPrice = 100.0m};
                parts.Add(part.PartNumber, part);
                part = new CarPart{PartNumber = "NumberFour", PartName = "NameFour", UnitPrice = 100.0m};
                parts.Add(part.PartNumber, part);
                foreach (var p in parts)
                {
                    // Part numbers printed out in *alphabetical* order (because they are strings).
                    Console.WriteLine("Part number = " + p.Value.PartNumber);
                }
            }
        }
        public sealed class CarPart
        {
            public string PartNumber;
            public string PartName;
            public Decimal UnitPrice;
        }
    }
