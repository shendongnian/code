    public class Test_Validation
    {
      public bool Test_User(string username)
      {
      // Setup your username pattern
        const string pattern = @"^[a-z0-9_-]{3,15}$"/*NICE SAMPLE Username REGEX!*/;
        // check if the pattern matches
        if (System.Text.RegularExpressions.Regex.IsMatch(/*The string to check the pattern on*/username, /* the regular expression pattern */pattern, /* a flag for REGEX */ System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            System.Console.WriteLine("  (match for '{0}' found)", pattern);
        }
        else
        {
            System.Console.WriteLine("Sorry, no match found");
        }
      }
    }
