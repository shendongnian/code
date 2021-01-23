    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    class Program
    {
      static void Main()
      {
        string input = "50000 Order Acme, #46405,53000,86232, for 4/17 60000";
        Regex t = new Regex(@"(?<!\d)([4-9]\d{4})(?!\d)", RegexOptions.Singleline) 
        MatchCollection theMatches = t.Matches(input) 
        for (int counter = 0; counter < theMatches.Count; counter++)
        {
          Console.WriteLine(theMatches[counter].Value); 
        }
      }
    }
