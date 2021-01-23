    private string GetCompressedString()
    {
        byte[] byteArray = Encoding.UTF8.GetBytes("Some long log string");
        using (var ms = new MemoryStream())
        {
            using (var gz = new GZipStream(ms, CompressionMode.Compress, true))
            {
                ms.Write(byteArray, 0, byteArray.Length);
            }
            ms.Position = 0;
            var compressedBytes = new byte[ms.Length];
            ms.Read(compressedBytes, 0, compressedBytes.Length);
            return Convert.ToBase64String(compressedBytes);
        }
    }
