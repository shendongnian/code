    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Chapter10Reader
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filename = "test.ch10";
    
                Console.WriteLine("Forwards:");
                List<long> positionsForward = new List<long>();
                using (PacketScanner scanner = PacketScanner.OpenFile(filename))
                {
                    scanner.MoveToBeforeStart();
                    PacketHeader header;
                    while ((header = scanner.NextHeader()) != null)
                    {
                        Console.WriteLine("Found header at {0}", header.FilePosition);
                        positionsForward.Add(header.FilePosition);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Backwards:");
                List<long> positionsBackward = new List<long>();
                using (PacketScanner scanner = PacketScanner.OpenFile(filename))
                {
                    scanner.MoveToEnd();
                    PacketHeader header;
                    while ((header = scanner.PreviousHeader()) != null)
                    {
                        positionsBackward.Add(header.FilePosition);
                    }
                }
                positionsBackward.Reverse();
                foreach (var position in positionsBackward)
                {
                    Console.WriteLine("Found header at {0}", position);
                }
    
                Console.WriteLine("Same? {0}", positionsForward.SequenceEqual(positionsBackward));
            }
        }
    }
