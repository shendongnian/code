    static IDictionary<string, List<string>> ParseFile(string path)
    {
        Dictionary<string, List<string>> queries = new Dictionary<string, List<string>>();
        using (var reader = File.OpenText(path))
        {
            while (parseQuery(reader, queries)) { }
        }
        return queries;
    }
    
    private static bool parseQuery(StreamReader reader, Dictionary<string, List<string>> queries)
    {
        StringBuilder sbQuery = new StringBuilder();
        StringBuilder sbArgs = new StringBuilder();
        // Read in query
        bool moreLines = ParseBlock(reader, sbQuery);
        if (moreLines)
        {
            while (moreLines)
            {
                string line = reader.ReadLine();
                // Check for the beginning of an args block.
                if (line != null && line.StartsWith("-->"))
                {
                    // Read in args
                    sbArgs.Append(line);
                    moreLines = ParseBlock(reader, sbArgs);
                    break;
                }
                // If this is not an args block, it is a new query
                // Save the last query and start over
                else
                {
                    AddQuery(queries, sbQuery.ToString(), sbArgs.ToString());
                    sbQuery = new StringBuilder();
                    sbQuery.Append(line); // Make sure we capture the last line
                    moreLines = ParseBlock(reader, sbQuery);
                }
            }
        }
        AddQuery(queries, sbQuery.ToString(), sbArgs.ToString());
        return moreLines;
    }
    
    private static bool ParseBlock(StreamReader reader, StringBuilder builder)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (string.IsNullOrWhiteSpace(line)) break;
    
            builder.Append(line + " ");
        }
        return line != null;
    }
    
    private static void AddQuery(Dictionary<string, List<string>> queries, string query, string args)
    {
        if (query.Length > 0)
        {
            List<string> lstParams;
            if (!queries.TryGetValue(query, out lstParams))
            {
                lstParams = new List<string>();
            }
            lstParams.Add(args);
            queries[query] = lstParams;
        }
    }
