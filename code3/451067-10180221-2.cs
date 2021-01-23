    public static IEnumerable<string> getMeaningfulLines(string filename)
    {
      System.IO.StreamReader file =
        new System.IO.StreamReader(filename);
        while (!file.EndOfStream)
        {
          //keep two lines that we care about
          yield return file.ReadLine();
          yield return file.ReadLine();
          //discard three lines that we don't need
          file.ReadLine();
          file.ReadLine();
          file.ReadLine();
        }
    }
    
    public static void Main()
    {
      foreach(string line in getMeaningfulLines(@"C:/log.txt"))
      {
        //or do whatever else you want with the "meaningful" lines.
        Console.WriteLine(line);
      }
    }
