    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static DateTime? GetFirstDateFromString(string input);
       {
          string pattern = @"\d{2}\.\d{2}\.\d{4}";
          Match m = Regex.Match(input, pattern);
          if (m.Success) {
             return DateTime.Parse(m.Value);
          return null;
       }
    }
