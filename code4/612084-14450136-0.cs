    public static async Task<bool> IsValidTextFileAsync(string path,
                                                        int scanLength = 4096)
    {
      using(var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using(var reader = new StreamReader(stream, Encoding.UTF8))
      {
        var bufferLength = (int)Math.Min(scanLength, stream.Length);
        var buffer = new char[bufferLength];
        var bytesRead = await reader.ReadBlockAsync(buffer, 0, bufferLength);
        reader.Close();
        if(bytesRead != bufferLength)
          throw new IOException("There was an error reading from the file.");
  
        for(int i = 0; i < bytesRead; i++)
        {
          var c = buffer[i];
          
          if(char.IsControl(c))
            return false;
        }
        return true;
      }
    }
