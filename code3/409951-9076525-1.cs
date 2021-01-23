    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
               
                byte[] text = Encoding.ASCII.GetBytes(new string('X', 10000));
                byte[] compress = Compress(text);
    
                Console.WriteLine("Compressed");
                foreach (var b in compress)
                {
                    Console.WriteLine("{0} ", b);
                }
                Console.ReadKey();
            }
    
            public static byte[] Compress(byte[] raw)
            {
                using (var memory = new MemoryStream())
                {
                    using (var gzip = new GZipStream(memory, CompressionMode.Compress, true))
                    {
                        gzip.Write(raw, 0, raw.Length);
                    }
                    return memory.ToArray();
                }
            }
        }
    }
