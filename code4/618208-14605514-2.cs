    using System.Text.RegularExpressions;
	
    public static bool ControlRegex(string input)
    {
       Match match = Regex.Match(input, @"([A-Za-z0-9\-]+)",RegexOptions.IgnoreCase);
       if (match.Success)
       {
         return true;
       }
    }
