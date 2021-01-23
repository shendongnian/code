    //Just get all lines from a file as an IEnumerable; handy helper method in general.
    public static IEnumerable<string> GetAllLines(string filename)
    {
      System.IO.StreamReader file =
        new System.IO.StreamReader(filename);
      while (!file.EndOfStream)
      {
        yield return file.ReadLine();
      }
    }
    
    public static IEnumerable<string> getMeaningfulLines2(string filename)
    {
      int counter = 0;
      //This will yield when counter is 0 or 1, and not when it's 2, 3, or 4.
      //The result is yield two, skip 3, repeat.
      foreach(string line in GetAllLines(filename))
      {
        if(counter < 2)
          yield return line;
    
        //add one to the counter and have it wrap, 
        //so it is always between 0 and 4 (inclusive).
        counter = (counter + 1) % 5;
      }
    }
