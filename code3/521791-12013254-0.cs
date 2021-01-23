    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
      public static void Main()
      {
        string str = "begin:'this is an 'example' text'"; 
        str = Regex.Replace(str, "(?<=')(.*?)'(?=.*')", "$1");  
        Console.WriteLine(str);
      }
    }
