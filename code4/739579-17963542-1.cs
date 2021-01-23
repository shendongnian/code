    public override Task<object> ReadFromStreamAsync(
                                 Type type, Stream readStream,
                                        HttpContent content,
                                             IFormatterLogger formatterLogger)
    {
        string typeName = content.Headers.GetValues("X-Type").First();
    
        // rest of the code based on typeName
    }
