    using System;
    using System.Text.RegularExpressions;
    
    class App
    {
      static void Main()
      {
        var input = "procurement-notice-1234.html";
        var pattern = @"procurement-notice-(\d+).html";
        var replacement = "/Bids/Details/$1";
        var res = Regex.Replace(input, pattern, replacement);
        Console.WriteLine(res);
        // will output /Bids/Details/1234
      }
    }
