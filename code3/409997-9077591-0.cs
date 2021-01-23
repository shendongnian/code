    byte[] inputData = File.ReadAllBytes();
    using (var output = new MemoryStream())
    {
        using (var compression = new GZipStream(output, CompressionMode.Compress,
                                                true))
        {
            compression.Write(inputData, 0, inputData.Length);
        }
        File.WriteAllBytes(@"c:\compressed.gz", output.ToArray());
    }
