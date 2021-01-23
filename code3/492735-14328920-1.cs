    public static async Task CompressFileAsync(string inputFile, string outputFile)
    {
      using (var inputStream = File.Open(inputFile, FileMode.Open, FileAccess.Read))
      using (var outputStream = File.Create(outputFile))
      using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress))
      {
        await inputStream.CopyToAsync(deflateStream);
        deflateStream.Close();
        outputStream.Close();
        inputStream.Close();
      }
    }
