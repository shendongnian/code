    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
    
          var matches = Regex.Matches("Line 1 this is any random text. \r\n Line 2 Another Line?! \r\n Line 3 End of text. ", "\\w+").Cast<Match>().Select(match => match.Value);
          foreach (string sWord in matches)
          {
            Console.WriteLine(sWord);
          }
    
        }
      }
    }
