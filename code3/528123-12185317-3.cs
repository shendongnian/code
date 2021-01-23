    public IEnumerable<string[]> ReadTSV(TextReader tr)
    {
      using(tr)
        for(string line = tr.ReadLine(); line != null; line = tr.ReadLine())
          yield return line.Split('\t');
    }
