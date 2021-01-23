    using System;
    using System.IO;
    using Ionic.Zlib;
    using System.Text;
    
    namespace Qobuz
    {
        public static class MySqlCompressHelper
        {
            public static byte[] MySqlCompress(this string str, CompressionLevel level = CompressionLevel.BestCompression)
            {
                return UTF8Encoding.UTF8.GetBytes(str).MySqlCompress(level);
            }
    
            public static byte[] MySqlCompress(this byte[] buffer, CompressionLevel level = CompressionLevel.BestCompression)
            {
                using (var output = new MemoryStream())
                {
                    output.Write(BitConverter.GetBytes((int)buffer.Length), 0, 4);
                    using (var compressor = new ZlibStream(output, CompressionMode.Compress, level))
                    {
                        compressor.Write(buffer, 0, buffer.Length);
                    }
    
                    return output.ToArray();
                }
            }
    
            public static string MySqlUncompressString(this byte[] buffer)
            {
                return UTF8Encoding.UTF8.GetString(buffer.MySqlUncompressBuffer());
            }
    
            public static byte[] MySqlUncompressBuffer(this byte[] buffer)
            {
                using (var output = new MemoryStream())
                {
                    using (var decompressor = new ZlibStream(output, CompressionMode.Decompress))
                    {
                        decompressor.Write(buffer, 4, buffer.Length - 4);
                    }
    
                    return output.ToArray();
                }
            }
        }
    }
  [1]: http://dotnetzip.codeplex.com/
