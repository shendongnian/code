    using System;
    using System.Text.RegularExpressions;
    
    static class Program
    {
      public static void Main()
      {
        string pattern1 = @"\t";
        Regex regex1 = new Regex(pattern1, RegexOptions.Compiled);
        string pattern2 = @"[^A-Za-z0-9~!#$^&*()_+|`\-=\\{}:"">?<\[\];',./ \r\n]";
        Regex regex2 = new Regex(pattern2, RegexOptions.Compiled);
    
        string input = "ABZabz09~!#$^&*()_+|`-=\\{}:\">?<[];',./ \r\nárvíztűrő\ttükörfúrógép";
        string temp = regex1.Replace(input, " ");
        string output = regex2.Replace(temp, "");
        Console.WriteLine(input);
        Console.WriteLine(output);
        Console.ReadKey(true);
      }
    }
