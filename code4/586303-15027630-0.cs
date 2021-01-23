    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main()
            {
                var minimalModel = File.ReadAllText("Model1.edmx");
    
                var encodedMinimalModel = Encode(minimalModel);
    
                var decodedMinimalModel = Decode(encodedMinimalModel);
            }
    
            private static string Decode(string encodedText)
            {
                var compressedBytes = Convert.FromBase64String(encodedText);
    
                var decompressedBytes = Decompress(compressedBytes);
    
                return Encoding.UTF8.GetString(decompressedBytes);
            }
    
            private static string Encode(string plainText)
            {
                var bytes = Encoding.UTF8.GetBytes(plainText);
    
                var compressedBytes = Compress(bytes);
    
                return Convert.ToBase64String(compressedBytes);
            }
    
            public static byte[] Decompress(byte[] bytes)
            {
                using (var memorySteam = new MemoryStream(bytes))
                {
                    using (var gzipStream = new GZipStream(memorySteam, CompressionMode.Decompress))
                    {
                        return ToByteArray(gzipStream);
                    }
                }
            }
    
            private static byte[] ToByteArray(Stream stream)
            {
                using (var resultMemoryStream = new MemoryStream())
                {
                    stream.CopyTo(resultMemoryStream);
    
                    return resultMemoryStream.ToArray();
                }
            }
    
            public static byte[] Compress(byte[] bytes)
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                    {
                        gzipStream.Write(bytes,0, bytes.Length);
                    }
    
                    return memoryStream.ToArray();
                }
            }
        }
    }
