    static string partPattern = @"^\s*(?<Key>\w*)\s+(?<Value>\w*)\s*$";
    
    static IEnumerable<IDictionary<string, string>> ReadParts(string path)
    {
        using (var reader = File.OpenText(path))
        {
            Dictionary<string, string> current = null;
            bool replicateBlock = false;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
    
                // This is a new replicate block, start a new dictionary
                if (line.StartsWith("REPLICATE"))
                {
                    replicateBlock = true;
                    current = new Dictionary<string, string>();
                }
                // This block ended, if it was a replicate block, return the dictionary.
                else if (line.Trim().CompareTo("}") == 0)
                {
                    if (replicateBlock)
                    {
                        yield return current;
                    }
                    replicateBlock = false;
                }
                else
                {
                    Match m = Regex.Match(line, partPattern);
                    if (replicateBlock && m.Groups[1].Length > 0 && m.Groups[2].Length > 0)
                    {
                        current.Add(m.Groups[1].Value, m.Groups[2].Value);
                    }
                }
            }
        }
    }
