    using System;
    using System.Text.RegularExpressions;
     
    class Program
    {
      static void Main()
      {
        string input = "ACTIVITY: \"{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, " +
                       "0xAA, 0x00, 0x57, 0xB2, 0x23}}\", Time:09:09:09:09";
        Match match = Regex.Match(input, @"((?:\s*\{*\s*(?:0x[\dA-F]+)\}*\,?)+)");
        if (match.Success)
        {
          string key = match.Groups[1].Value;
          Console.WriteLine(key);
        }
        else
        {
          Console.WriteLine("NO MATCH");
        }
      }
    }
