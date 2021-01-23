    using System;
    using System.Text.RegularExpressions;
     
    public class Example
    {
       public static void Main()
       {
          var re = @"(?x)  # ignore spaces and comments
    (?=                    # lookahead (zero width)
      (
        \(                 # first (
        (?:
          (?<open> \( )*   # open++
          [^()]+
          (?<-open> \) )*  # open--
        )+
        \)                 # last )
        (?(open)(?!))      # fail if unblanaced: open > 0
      )
    )
    \(                     # eat a (, to advance the match a char";
          var str = "a + ((b + (c + d)) + (e + f)) + (x + ((y) + (z)) + x)";
     
          var m = Regex.Matches(str, re);
     
          Console.WriteLine("Matched: ");
          foreach (Match i in m)
            Console.WriteLine(i.Groups[1]);
       }
    }
