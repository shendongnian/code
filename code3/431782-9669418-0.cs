    private class SEOSymbolReplacement
    {
       private Regex _rx;
       private string _replacementString;
       public SEOSymbolReplacement(Regex r, string replacement)
       {
         //null-checks required.
         _rx = r;
         _replacementString = replacement;
       }
       public string Execute(string input)
       {
         /null-check required
         return _rx.Replace(input, _replacementString);
       }
    }
    
    private static readonly SEOSymbolReplacement[] Replacements = { 
	  new SEOSymbolReplacement(new Regex(@"#", RegexOptions.Compiled), "Sharp"),
	  new SEOSymbolReplacement(new Regex(@"\+", RegexOptions.Compiled), "Plus"),
	  new SEOSymbolReplacement(new Regex(@"&", RegexOptions.Compiled), " And "),
	  new SEOSymbolReplacement(new Regex(@"[|:'\\/,_]", RegexOptions.Compiled), "-"),
	  new SEOSymbolReplacement(new Regex(@"\s+", RegexOptions.Compiled), "-"),
	  new SEOSymbolReplacement(new Regex(@"[^\p{L}\d-]", 
                               RegexOptions.IgnoreCase | RegexOptions.Compiled), ""),
	  new SEOSymbolReplacement(new Regex(@"-{2,}", RegexOptions.Compiled), "-")};
	
    /// <summary>
	/// Transforms the string into an SEO-friendly string.
	/// </summary>
	/// <param name="str"></param>
	public static string ToSEOPathString(this string str)
	{
		if (str == null)
			return null;
		string toReturn = str;
		foreach (var replacement in DefaultReplacements)
		{
			toReturn = replacement.Execute(toReturn);
		}
		return toReturn;
	}
