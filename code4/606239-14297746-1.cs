    public static async Task CompressToFileAsync(byte[] buffer, 
                                                 string outputFile)
    {
      using (var inputStream = new MemoryStream(buffer))
        await CompressToFileAsync(inputStream, outputFile);
    }
    public static async Task CompressToFileAsync(Stream inputStream, 
                                                 string outputFile)
    {
      using (var outputStream = File.Create(outputFile))
      using (var gzip = new GZipStream(outputStream, CompressionMode.Compress))
      {
        await inputStream.CopyToAsync(gzip);
        gzip.Close();
      }
    }
    public static async Task<MemoryStream> DecompressFromFileAsync(string inputFile)
    {
      var outputStream = new MemoryStream();
      using (var inputStream = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var gzip = new GZipStream(inputStream, CompressionMode.Decompress))
      {
        await gzip.CopyToAsync(outputStream);
        gzip.Close();
        inputStream.Close();
        // After writing to the MemoryStream, the position will be the size
        // of the decompressed file, we should reset it back to zero before returning.
        outputStream.Position = 0;
        return outputStream;
      }
    }
