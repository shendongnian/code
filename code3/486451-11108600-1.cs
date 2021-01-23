    // Check for lines that are a key-value pair, separated by whitespace.
    static string partPattern = @"^\s*(?<Key>\w*)\s+(?<Value>\w*)\s*$";
    
    static IEnumerable<IDictionary<string, string>> ReadParts(string path)
    {
        using (var reader = File.OpenText(path))
        {
            Dictionary<string, string> currentDictionary = null;
            bool replicateBlock = false;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Ignore lines that just contain whitespace
                if (string.IsNullOrWhiteSpace(line)) continue;
    
                // This is a new replicate block, start a new dictionary
                if (line.StartsWith("REPLICATE"))
                {
                    replicateBlock = true;
                    currentDictionary = new Dictionary<string, string>();
                }
                // This block ended, if it was a replicate block, return the dictionary.
                else if (line.Trim().CompareTo("}") == 0)
                {
                    if (replicateBlock)
                    {
                        yield return currentDictionary;
                        // Reset this now that we're done with the current block.
                        replicateBlock = false;
                    }
                }
                else
                {
                    // Since our regex used groupings (?<Key> and ?<Value>),
                    // we can do a match and check to see if our groupings
                    // found anything.  If they did, extract the key and value.
                    Match m = Regex.Match(line, partPattern);
                    if (replicateBlock && m.Groups[1].Length > 0 && m.Groups[2].Length > 0)
                    {
                        currentDictionary.Add(m.Groups[1].Value, m.Groups[2].Value);
                    }
                }
            }
        }
    }
