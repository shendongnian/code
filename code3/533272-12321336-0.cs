    using System.Text.RegularExpressions;
    class RegExSample 
    {
      static void Main() 
      {
        string input = "Why Don't You watch <NAME>This is Spinal Tap</NAME> on <DAY>Friday</DAY> or whenever?";
        string output = Regex.Replace(input, @"((?<!^)\b[A-Z])(?=[^<>]+<[^\/>][^>]+>)",
          m => m.Value.ToLower());
        System.Console.WriteLine(output);
      }
    }
