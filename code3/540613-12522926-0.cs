    using System.Text.RegularExpressions;
    
    Regex re = new Regex("and", RegexOptions.IgnoreCase);
    string and = "This is my input string with and string in between."
    
    re.Replace(and, ",");
