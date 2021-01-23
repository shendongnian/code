    public static IEnumerable<int> ReadInts(TextReader tr)
    {
      //put using here to have this manage cleanup, but in calling method
      //is probably better
      for(string line = tr.ReadLine(); line != null; line = tr.ReadLine())
        if(line.Length != 0 && line[0] != '#')
          yield return int.Parse(line);
    }
