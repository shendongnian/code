    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
     public static void Main()
     {
      string input = "ssdf bonnets sdf sdf sdf ";
      string pattern_1 = "f";
      string replacement = "a";
      Regex rgx_1 = new Regex(pattern_1);
      string result = rgx_1.Replace(input, replacement);
      string pattern_2 = "b";
      Regex rgx_2 = new Regex(pattern_2);
      result = rgx_2.Replace(result, replacement);
      string pattern_3 = "s";
      Regex rgx_3 = new Regex(pattern_3);
      result = rgx_3.Replace(result, replacement);
      Console.WriteLine("Original String: {0}", input);
      Console.WriteLine("Replacement String: {0}", result);                             
     }
    }
