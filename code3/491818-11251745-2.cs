    using System;
    using System.Text.RegularExpressions;
 
    class Program
    {
      static void Main()
      {
        string input = "Random string CA761232-ED42-11CE-BACD-00AA0057B223 random string";
        Match match = Regex.Match(input,
          @"((?:(?:\s*\{*\s*(?:0x[\dA-F]+)\}*\,?)+)|(?<![a-f\d])[a-f\d]{32}(?![a-f\d])|" +
          @"(?:\{\(|)(?<![A-F\d])[A-F\d]{8}(?:\-[A-F\d]{4}){3}\-[A-F\d]{12}(?![A-F\d])(?:\}|\)|))");
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
