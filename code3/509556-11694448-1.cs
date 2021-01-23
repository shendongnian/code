    using System;
    using System.Text.RegularExpressions;
 
    class Program
    {
      static void Main()
      {
        string input = "select ceiling(a.interest) as interest, a.myID as mID, a.studentID as sID from mytable";
        string column = "a.myID";
        string pattern = "((?<=\\bselect)\\s+[^,]*\\b" + Regex.Escape(column) + "\\b[^,]*\\s*,?|\\s*,\\s*[^,]*\\b" + Regex.Escape(column) + "\\b[^,]*(?=(?:,|\\sfrom\\b)))";
        string output = Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase);
        Console.WriteLine(output);
      }
    }
