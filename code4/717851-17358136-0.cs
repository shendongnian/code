    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var uncompressed = Encoding.UTF8.GetBytes("Mary had a little lamb");
            var compressed = GZIPCompress(uncompressed);
            Console.WriteLine(compressed.Length);
            Console.WriteLine(Convert.ToBase64String(compressed));
        }
        
        static byte[] GZIPCompress(byte[] data)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(memoryStream, 
                                                       CompressionMode.Compress))
                {
                    gZipStream.Write(data, 0, data.Length);
                }
    
                return memoryStream.ToArray();
            }
        }
    }
