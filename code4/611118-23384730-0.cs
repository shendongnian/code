    public static void DeCompressFile(string CompressedFile, string DeCompressedFile)
    {
        byte[] buffer = new byte[1024 * 1024];
        using (System.IO.FileStream fstrmCompressedFile = System.IO.File.OpenRead(CompressedFile)) // fi.OpenRead())
        {
            using (System.IO.FileStream fstrmDecompressedFile = System.IO.File.Create(DeCompressedFile))
            {
                using (System.IO.Compression.GZipStream strmUncompress = new System.IO.Compression.GZipStream(fstrmCompressedFile,
                        System.IO.Compression.CompressionMode.Decompress))
                {
                    int numRead = strmUncompress.Read(buffer, 0, buffer.Length);
                    while (numRead != 0)
                    {
                        fstrmDecompressedFile.Write(buffer, 0, numRead);
                        fstrmDecompressedFile.Flush();
                        numRead = strmUncompress.Read(buffer, 0, buffer.Length);
                    } // Whend
                    //int numRead = 0;
                    //while ((numRead = strmUncompress.Read(buffer, 0, buffer.Length)) != 0)
                    //{
                    //    fstrmDecompressedFile.Write(buffer, 0, numRead);
                    //    fstrmDecompressedFile.Flush();
                    //} // Whend
                    strmUncompress.Close();
                } // End Using System.IO.Compression.GZipStream strmUncompress 
                fstrmDecompressedFile.Flush();
                fstrmDecompressedFile.Close();
            } // End Using System.IO.FileStream fstrmCompressedFile 
            fstrmCompressedFile.Close();
        } // End Using System.IO.FileStream fstrmCompressedFile 
    } // End Sub DeCompressFile
    // http://www.dotnetperls.com/decompress
    public static byte[] Decompress(byte[] gzip)
    {
        byte[] baRetVal = null;
        using (System.IO.MemoryStream ByteStream = new System.IO.MemoryStream(gzip))
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (System.IO.Compression.GZipStream stream = new System.IO.Compression.GZipStream(ByteStream
                , System.IO.Compression.CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
                {
                    int count = 0;
                    count = stream.Read(buffer, 0, size);
                    while (count > 0)
                    {
                        memory.Write(buffer, 0, count);
                        memory.Flush();
                        count = stream.Read(buffer, 0, size);
                    }
                    baRetVal = memory.ToArray();
                    memory.Close();
                }
                stream.Close();
            } // End Using System.IO.Compression.GZipStream stream 
            ByteStream.Close();
        } // End Using System.IO.MemoryStream ByteStream
        return baRetVal;
    } // End Sub Decompress
