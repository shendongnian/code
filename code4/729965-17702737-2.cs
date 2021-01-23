    private static IEnumerable<string> ExtractChunks(string format, string data)
    {
        if(format.Length != data.Length)
            throw new ArgumentException("Format length must match Data length");
        if(data.Length == 0)
            throw new ArgumentException("Invalid Data length");
        
        char prevFormat = '\0';
        char currentFormat = format[0];
        
        var chunks = new List<string>();
        var builder = new StringBuilder();
        
        unsafe
        {
            fixed(char * indexer = data)
            {
                var index = -1;
                
                while(data.Length > ++index)
                {
                    prevFormat = currentFormat;
                    currentFormat = format[index];
                    
                    if(currentFormat != prevFormat)
                    {
                        chunks.Add(builder.ToString());
                        builder.Clear();
                    }
                    
                    builder.Append((*(indexer + index)));
                }
                
                chunks.Add(builder.ToString());
                builder.Clear();
            }
        }
        
        return chunks;
    }
