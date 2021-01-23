    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string pattern = "!=|<=|>=|\\|\\||\\&\\&|\\d+|[a-z()+\\-*/<>]";
          string sentence = "(x+35>5*y)&&(z>=3 || k!=x)";
    
          foreach (Match match in Regex.Matches(sentence, pattern))
             Console.WriteLine("Found '{0}' at position {1}", 
                               match.Value, match.Index);
       }
    }
