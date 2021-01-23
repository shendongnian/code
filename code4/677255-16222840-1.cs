    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static DateTime? GetFirstDateFromString(string input);
       {
          string pattern = @"\d{2}\.\d{2}\.\d{4}";
          Match m = Regex.Match(input, pattern);
          DateTime result;
          foreach(string value in match.Groups)  
              if (DateTime.TryParseExact(match.Groups[1], "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)
                  return result;
          return null;
       }
    }
