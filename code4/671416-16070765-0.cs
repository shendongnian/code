    public static byte[] Compress(byte[] data)
    {
        using (var output = new MemoryStream())
        {
            using (var compression = new GZipStream(output, CompressionMode.Compress))
            {
                compression.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
    }
    
    public static byte[] Compress(byte[] data)
    {
        using (var output = new MemoryStream())
        {
            using (var compression = new GZipStream(output, CompressionMode.Decompress))
            {
                compression.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
    }
