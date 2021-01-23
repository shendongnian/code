    public async void ReadAsync()
    {
        byte[] data = new byte[1024];
        int numBytesRead = await _stream.ReadAsync(data, 0, 1024);
    
        // Process data ...
    
        // Read again.
        if(numBytesRead > 0)
        {
            ReadAsync();
        }
    }
