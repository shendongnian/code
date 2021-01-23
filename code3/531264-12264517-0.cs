    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
      public static void Main()
      {
        string input = @"\\10.0.1.1\ITClient\001\0012\";
        string output = Regex.Replace(input, @"^(\\\\[^\\]+\\)[^\\]+(.*)$", @"$1Archive$2");
        Console.WriteLine(output);
      }
    }
