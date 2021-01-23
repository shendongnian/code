    public static class Find
    {
      static readonly Regex CapitalLetter = new Regex("[A-Z]");
      
      public static int FirstCapitalLetter(string input)
      {
        Match match = CapitalLetter.Match(input);
        // I would go with -1 here, personally.
        return match.Success ? match.Index : 0;
      }
    }
