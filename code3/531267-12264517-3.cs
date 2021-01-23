    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
      public static void Main()
      {
        string input = @"\\10.0.1.1\ITClient\001\0012\";
        Regex re = new Regex(@"(?<=[^\\]\\)[^\\]+");
        string output = re.Replace(input, "Archive", 1);
        Console.WriteLine(output);
      }
    }
