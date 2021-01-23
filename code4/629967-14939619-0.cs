    string ReplaceWithoutOverlap(string input, IDictionary<string, string> replacements)
    {
        var processedCharCount = 0;
    	var sb = new StringBuilder();
    	while (processedCharCount < input.Length) {
    		var replacement = replacements
                    .Select(r => Tuple.Create(r.Key, input.IndexOf(r.Key, processedCharCount)))
                    .Where(t => t.Item2 != -1)
                    .OrderBy(t => t.Item2)
                    .ThenByDescending(t => t.Item1.Length)
                    .FirstOrDefault();
    									  
    		if (replacement == null)
    		{
    			break;
    		}
    
    		sb.Append(input, processedCharCount, replacement.Item2 - processedCharCount);
    		sb.Append(replacements[replacement.Item1]);
    		processedCharCount = replacement.Item2 + replacement.Item1.Length;
    	}
    	
    	sb.Append(input.Substring(processedCharCount));
    	return sb.ToString();
    }
