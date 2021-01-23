    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
       public static void Main()
       {
          string[] strings = {
              "ABC123",
              "ABC245", 
              "ABC435",
              "ABC Oh say can You see"
          };
          string pattern = @"ABC(?!123)";
          foreach (string str in strings)
             Console.WriteLine(
                 "\"{0}\" {1} match.", 
                 str, Regex.IsMatch(str, pattern) ? "does" : "does not"
             );
       }
    }
