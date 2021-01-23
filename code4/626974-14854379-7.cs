    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    static class Program
    {
      public static void Main()
      {
        byte[] bulletBytes = new byte[] { 0xE2, 0x80, 0xA2 };
        string bullet= Encoding.UTF8.GetString(bulletBytes);
    
        string pattern1 = @"[\t" + bullet + "]";
        Regex regex1 = new Regex(pattern1, RegexOptions.Compiled);
        string pattern2 = @"[^A-Za-z0-9~!#$^&*()_+|`\-=\\{}:"">?<\[\];',./ \r\n]";
        Regex regex2 = new Regex(pattern2, RegexOptions.Compiled);
    
        string input = 
          bullet + "ABZabz09~!#$^&*()_+|`-=\\{}:\">?<[];',./ \r\n" + 
          bullet + "árvíztűrő\ttükörfúrógép";
        string temp = regex1.Replace(input, " ");
        string output = regex2.Replace(temp, "");
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(input);
        Console.WriteLine(output);
        Console.ReadKey(true);
      }
    }
