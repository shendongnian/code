    namespace ConsoleApplication1
    {
      using System;
      using System.Net;
      class Program
      {
        static void Main()
        {
          //var request = WebRequest.Create("https://www.google.com"); // page will result in html/text
          var request = WebRequest.Create(@"https://www.google.de/logos/2013/douglas_adams_61st_birthday-1062005.2-res.png");
          request.Method = "HEAD"; // only request header information, don't download the whole file
          var response = request.GetResponse();
          Console.WriteLine(response.ContentType);
          Console.WriteLine("Done.");
          Console.ReadLine();
        }
      }
    }
