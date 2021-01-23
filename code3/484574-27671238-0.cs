    var buffer = await response.Content.ReadAsBufferAsync();
    byte [] rawBytes = new byte[buffer.Length];
    using (var reader = DataReader.FromBuffer(buffer))
    {
        reader.ReadBytes(rawBytes);
    }
                            
    var res = Encoding.UTF8.GetString(rawBytes, 0, rawBytes.Length);   
