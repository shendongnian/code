    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result))
    using (Stream stream = response.GetResponseStream())
    using (MemoryStream memory = new MemoryStream())
    using (GZipStream gzip = new GZipStream(memory, CompressionMode.Decompress))
    {
        byte[] compressedBuffer = new byte[8192];
        byte[] uncompressedBuffer = new byte[8192];
        List<byte> output = new List<byte>();
        while (stream.CanRead)
        {
            int readCount = stream.Read(compressedBuffer, 0, compressedBuffer.Length);
                        
            memory.Write(compressedBuffer.Take(readCount).ToArray(), 0, readCount);
            memory.Position = memory.Position - readCount;
            int uncompressedLength = gzip.Read(uncompressedBuffer, 0, uncompressedBuffer.Length);
            output.AddRange(uncompressedBuffer.Take(uncompressedLength));
            if (!output.Contains(0x0A)) continue;
            byte[] bytesToDecode = output.Take(output.LastIndexOf(0x0A) + 1).ToArray();
            string outputString = Encoding.UTF8.GetString(bytesToDecode);
            output.RemoveRange(0, bytesToDecode.Length);
            string[] lines = outputString.Split(new[] { Environment.NewLine }, new StringSplitOptions());
            for (int i = 0; i < (lines.Length - 1); i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
