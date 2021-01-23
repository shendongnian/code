     // Check for lines that are a key-value pair, separated by whitespace.
    // Note that value is optional
    static string partPattern = @"^(?<Key>\w*)(\s+(?<Value>\w*))?$";
    
    static IEnumerable<IDictionary<string, string>> ReadParts(string path)
    {
        using (var reader = File.OpenText(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Ignore lines that just contain whitespace
                if (string.IsNullOrWhiteSpace(line)) continue; 
    
                // This is a new replicate block, start a new dictionary
                if (line.Trim().CompareTo("REPLICATE") == 0)
                {
                    yield return parseReplicateBlock(reader);
                }
            }
        }
    }
    
    private static IDictionary<string, string> parseReplicateBlock(StreamReader reader)
    {
        // Make sure we have an opening brace
        VerifyOpening(reader);
        string line;
        var currentDictionary = new Dictionary<string, string>();
        while ((line = reader.ReadLine()) != null)
        {
            // Ignore lines that just contain whitespace
            if (string.IsNullOrWhiteSpace(line)) continue;
    
            line = line.Trim();
    
            // Since our regex used groupings (?<Key> and ?<Value>), 
            // we can do a match and check to see if our groupings 
            // found anything. If they did, extract the key and value. 
            Match m = Regex.Match(line, partPattern);
            if (m.Groups["Key"].Length > 0)
            {
                currentDictionary.Add(m.Groups["Key"].Value, m.Groups["Value"].Value);
            }
            else if (line.CompareTo("}") == 0)
            {
                return currentDictionary;
            }
        }
        // We exited the loop before we found a closing brace, throw an exception
        throw new ApplicationException("Missing closing brace");
    }
    
    private static void VerifyOpening(StreamReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // Ignore lines that just contain whitespace
            if (string.IsNullOrWhiteSpace(line)) continue;
    
            if (line.Trim().CompareTo("{") == 0)
            {
                return;
            }
            else
            {
                throw new ApplicationException("Missing opening brace");
            }
        }
        throw new ApplicationException("Missing opening brace");
    }
