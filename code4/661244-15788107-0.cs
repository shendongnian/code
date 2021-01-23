    using System;
    using System.IO;
    using System.Collections.Generic;
    namespace Demo
    {
        internal class Program
        {
            public static List<string> RandomlyChooseLinesFromFile(string filename, int n, Random rng)
            {
                var result = new List<string>(n);
                int index = 0;
                foreach (var line in File.ReadLines(filename))
                {
                    if (index < n)
                    {
                        result.Add(line);
                    }
                    else
                    {
                        int r = rng.Next(0, index + 1);
                        if (r < n)
                            result[r] = line;
                    }
                    ++index;
                }
                return result;
            }
            // Test RandomlyChooseLinesFromFile()
            private static void Main(string[] args)
            {
                Directory.CreateDirectory("C:\\TEST");
                string testfile = "C:\\TEST\\TESTFILE.TXT";
                File.WriteAllText(testfile, "0\n1\n2\n3\n4\n5\n6\n7\n8\n9");
                var rng = new Random();
                int trials = 100000;
                var counts = new int[10];
                for (int i = 0; i < trials; ++i)
                {
                    string line = RandomlyChooseLinesFromFile(testfile, 1, rng)[0];
                    int index = int.Parse(line);
                    ++counts[index];
                }
                // If this algorithm is correct, each line should be chosen
                // approximately 10% of the times.
                Console.WriteLine("% times each line was chosen:\n");
                for (int i = 0; i < 10; ++i)
                {
                    Console.WriteLine("{0} = {1}%", i, 100*counts[i]/(double)trials);
                }
            }
        }
    }
