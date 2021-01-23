    static IEnumerable<IDictionary<string, string>> ReadParts(string path)
    {
        using (var reader = File.OpenText(path))
        {
            string currentName = null;
            var currentMap = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (line == "{")
                {
                    if (currentName == null || currentMap != null)
                    {
                        throw new BadDataException("Open brace at wrong place");
                    }
                    currentMap = new Dictionary<string, string>();
                }
                else if (line == "}")
                {
                    if (currentName == null || currentMap == null)
                    {
                        throw new BadDataException("Closing brace at wrong place");
                    }
                    // Isolate the "REPLICATE-only" requirement to a single
                    // line - if you ever need other bits, you can change this.
                    if (currentName == "REPLICATE")
                    {
                        yield return currentMap;
                    }
                    currentName = null;
                    currentMap = null;
                }
                else if (!line.StartsWith("\t"))
                {
                    if (currentName != null || currentMap != null)
                    {
                        throw new BadDataException("Section name at wrong place");
                    }
                    currentName = line;
                }
                else
                {
                    if (currentName == null || currentMap == null)
                    {
                        throw new BadDataException("Name/value pair at wrong place");
                    }
                    var parts = line.Substring(1).Split('\t');
                    if (parts.Length != 2)
                    {
                        throw new BadDataException("Invalid name/value pair");
                    }
                    currentMap[parts[0]] = parts[1];
                }                
            }
        }
    }
