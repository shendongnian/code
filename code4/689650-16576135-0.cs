    private const string FormatTokenGroupName = "token";
    private static readonly Regex FormatRegex = new Regex(@"(?<!\{)\{(?<" + FormatTokenGroupName + @">\w+)\}(?!\})", RegexOptions.Compiled);
    public static string Format(this string source, IDictionary<string, string> replacements)
    {
    	if (string.IsNullOrWhiteSpace(source) || replacements == null)
    	{
    		return source;
    	}
    
    	string replaced = replacements.Aggregate(source,
    		(current, pair) =>
    			FormatRegex.Replace(current,
    				new MatchEvaluator(match =>
    					(match.Groups[FormatTokenGroupName].Value == pair.Key
    						? pair.Value : match.Value))));
    
    	return replaced.Replace("{{", "{").Replace("}}", "}");
    }
