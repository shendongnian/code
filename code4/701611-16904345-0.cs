    public static async Task<string> MyReadLineAsync(this Stream stream, Encoding encoding)
    {
      using ( StreamReader reader = new StreamReader( stream , encoding ) )
      {
        return reader.ReadToEndAsync() ;
      }
    }
