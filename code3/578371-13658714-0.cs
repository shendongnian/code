    public IList<string> method()
    {
      return seq.ToList();
    }
    IEnumerable<string> seq
    {
      get
      {
        for (int i = 0; i < 1000; i++)
        {
          yield return i.ToString();
        }
      }
    }
