    private static IEnumerable<string> ExtractChunks(string format, string data)
    {
        if(format.Length != data.Length)
            throw new ArgumentException("Format length must match Data length");
        if(data.Length == 0)
            throw new ArgumentException("Invalid Data length");
    
        char prevFormat = '\0';
        char currentFormat = format[0];
        
        var prevIndex = 0;
        var index = 1;
        
        var message = data.ToCharArray();
        var chunks = new List<string>();
        
        while(data.Length > index)
        {
            prevFormat = currentFormat;
            currentFormat = format[index];
            
            if(currentFormat != prevFormat)
            {
                chunks.Add(new string(message, prevIndex, index - prevIndex));
                prevIndex = index;
            }
            
            index++;
        }
        
        chunks.Add(new string(message, prevIndex, index - prevIndex));
        
        return chunks;
    }
