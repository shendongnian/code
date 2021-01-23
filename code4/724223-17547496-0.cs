    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication15
    {
        class Program
        {
            const int FILE_COUNT = 9000;
            const int DATA_LENGTH = 100;
            static void Main(string[] args)
            {
                if (Directory.Exists(@"c:\Temp\")) Directory.Delete(@"c:\Temp\", true);
                Directory.CreateDirectory(@"c:\Temp\");
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < FILE_COUNT; i++)
                {
                    string data = new string(i.ToString()[0], DATA_LENGTH);
                    File.AppendAllText(string.Format(@"c:\Temp\{0}.txt", i), data);
                }
                watch.Stop();
                Console.WriteLine("Wrote 90,000 files single-threaded in {0}ms", watch.ElapsedMilliseconds);
    
                Directory.Delete(@"c:\Temp\", true);
                Directory.CreateDirectory(@"c:\Temp\");
    
                watch = Stopwatch.StartNew();
                Parallel.For(0, FILE_COUNT, i =>
                {
                    string data = new string(i.ToString()[0], DATA_LENGTH);
                    File.AppendAllText(string.Format(@"c:\Temp\{0}.txt", i), data);
                });
                watch.Stop();
                Console.WriteLine("Wrote 90,000 files multi-threaded in {0}ms", watch.ElapsedMilliseconds);
            }
        }
    }
