    using System.Text.RegularExpressions;
	
    public bool ControlRegex(string input)
    {
       Match match = Regex.Match(input, @"example regex like([A-Za-z0-9\-]+)\.aspx$",RegexOptions.IgnoreCase);
       if (match.Success)
       {
         return true;
       }
    }
