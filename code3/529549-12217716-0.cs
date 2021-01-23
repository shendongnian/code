    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
      public static void Main()
      {
        string post = "<font color=\"#000fff\" size=\"1\" face=\"Arial\">Genuine Windows® 7 Home Premium (64-bit)</font>";
        post = Regex.Replace(post, "<font color=\"([a-fA-F0-9\\#]+)\"[^>]*>(.*?)</font>", 
          m => "[color=\"" + m.Groups[1].Value + "\"]" + m.Groups[2].Value + "[/color]");
        Console.WriteLine(post);
      }
    }
