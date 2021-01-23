      static void Main(string[] args)
      {          
          DirectoryInfo dir = new DirectoryInfo(@"c:\");
          Console.WriteLine(dir.FullName);
          Console.ReadLine();
      }       
