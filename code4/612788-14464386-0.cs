    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace FileCreator
    {
        class Program
        {
            static void Main(string[] args)
            {
                string folder = @"d:\temp";
                CreateWithFileStream(folder);
                CreateWithFileWriteBytes(folder);
                CreateWithParallelFileWriteBytes(folder);
            }
    
            private static byte[] GetFileContent(int i)
            {
                Random r = new Random(i);
                byte[] buffer = new byte[1024];
                r.NextBytes(buffer);
                return buffer;
            }
    
            private static void CreateWithFileStream(string folder)
            {
                var sw = new Stopwatch();
                sw.Start();
    
                for (int i = 0; i < 1000; i++)
                {
                    string path = Path.Combine(folder, string.Format("file{0}.dat", i));
    
                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.None))
                    {
                        byte[] bytes = GetFileContent(i);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
    
                Console.WriteLine("Time for CreateWithFileStream: {0}ms", sw.ElapsedMilliseconds);
            }
    
            private static void CreateWithFileWriteBytes(string folder)
            {
                var sw = new Stopwatch();
                sw.Start();
    
                for (int i = 0; i < 1000; i++)
                {
                    string path = Path.Combine(folder, string.Format("file{0}.dat", i));
                    File.WriteAllBytes(path, GetFileContent(i));
                }
    
                Console.WriteLine("Time for CreateWithFileWriteBytes: {0}ms", sw.ElapsedMilliseconds);
            }
    
            private static void CreateWithParallelFileWriteBytes(string folder)
            {
                var sw = new Stopwatch();
                sw.Start();
    
                Parallel.For(0, 1000, (i) =>
                {
                    string path = Path.Combine(folder, string.Format("file{0}.dat", i));
                    File.WriteAllBytes(path, GetFileContent(i));
                });
    
                Console.WriteLine("Time for CreateWithParallelFileWriteBytes: {0}ms", sw.ElapsedMilliseconds);
            }
        }
    }
