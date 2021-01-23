    public async Task ReadAsync()
    {
      byte[] data = new byte[1024];
      while (true)
      {
        int numBytesRead = await _stream.ReadAsync(data, 0, 1024);
        if (numBytesRead == 0)
          return;
        // Process data ...
      }
    }
