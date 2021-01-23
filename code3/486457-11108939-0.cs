    private IEnumerable<IDictionary<string, string>> ParseFile(System.IO.TextReader reader)
    {
        string token = reader.ReadLine();
        while (token != null)
        {
            if (token.StartsWith("REPLICATE"))
            {
                token = reader.ReadLine();
                yield return ParseBlock(ref token, reader);
            }
        }
    }
    private IDictionary<string, string> ParseBlock(ref string token, System.IO.TextReader reader)
    {
        if (token != "{")
        {
            throw new Exception("Missing opening brace.");
        }
        token = reader.ReadLine();
        
        var result = ParseValues(ref token, reader);
        if (token != "}")
        {
            throw new Exception("Missing closing brace.");
        }
        return result;
    }
    private IDictionary<string, string> ParseValues(ref string token, System.IO.TextReader reader)
    {
        IDictionary<string, string> result = new Dictionary<string, string>();
        while (token != "}")
        {
            var args = token.Split('\t');
            if (args.Length < 2)
            {
                throw new Exception();
            }
            result.Add(args[0], args[1]);
            token = reader.ReadLine();
        }
        return result;
    }
