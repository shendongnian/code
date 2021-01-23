    Use Linq 
      using System.Linq;
    
      string word = "soHaMH";
      var capChars = word.Where(c => char.IsUpper(c)).Select(c => c);
      char capChar = capChars.FirstOrDefault();
      int index = word.IndexOf(capChar); 
    
    
    Using c# 
    
    using System.Text.RegularExpressions;
    
    string word = "soHaMH";
    Match match= Regex.Match(word, "[A-Z]");
    index = word.IndexOf(match.ToString());
