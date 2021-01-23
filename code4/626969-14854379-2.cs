    using System;
    using System.Text.RegularExpressions;
    
    static class Program
    {
      public static void Main()
      {
        string pattern = @"[^A-Za-z0-9~!#$^&*()_+|`\-=\\{}:"">?<\[\];',./ ]|\t";
        Regex regex = new Regex(pattern, RegexOptions.Compiled);
    
        string input = "ABZabz09~!#$^&*()_+|`-=\\{}:\">?<[];',./ árvíztűrő tükörfúrógép\t";
        string output = regex.Replace(input, "÷");
        Console.WriteLine(input);
        Console.WriteLine(output);
        Console.ReadKey(true);
      }
    }
