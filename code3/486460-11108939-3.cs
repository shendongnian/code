    private IEnumerable<IDictionary<string, string>> ParseFile(System.IO.TextReader reader)
    {
        string token = reader.ReadLine();
        while (token != null)
        {
            bool isReplicate = token.StartsWith("REPLICATE");
            token = reader.ReadLine(); //consume this token to either skip it or parse it
            if (isReplicate)
            {     
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
        token = reader.ReadLine();
        return result;
    }
    private IDictionary<string, string> ParseValues(ref string token, System.IO.TextReader reader)
    {
        IDictionary<string, string> result = new Dictionary<string, string>();
        while (token != "}" and token != null)
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
