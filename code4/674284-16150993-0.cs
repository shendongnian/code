    namespace ConsoleApplication1
    {
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader(@"D:\\TextFile1.txt"))
            {
                int count = GetPatchCount(streamReader);
                Console.WriteLine("NUmber of // : {0}",  count);
            }
            Console.ReadLine();
        }
        private static int GetPatchCount(StreamReader reader)
        {
            int count = 0;
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    if ((line.Length > 1) && (!line.StartsWith("//")))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
    }
