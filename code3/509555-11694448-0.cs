    using System;
    using System.Text.RegularExpressions;
 
    class Program
    {
      static void Main()
      {
        string input = "select a.column, a.myID, a.studentID from mytable";
        string column = "a.studentID";
        string pattern = "((?<!,)\\s*\\b" + Regex.Escape(column) + "\\b\\s*,?|\\s*,\\s*" + Regex.Escape(column) + "\\b)";
        string output = Regex.Replace(input, pattern, "");
        Console.WriteLine(output);
      }
    }
