    public static class Find
    {
      // Apparently the regex below works for non-ASCII uppercase
      // characters (so, better than A-Z).
      static readonly Regex CapitalLetter = new Regex(@"\p{Lu}");
      
      public static int FirstCapitalLetter(string input)
      {
        Match match = CapitalLetter.Match(input);
        // I would go with -1 here, personally.
        return match.Success ? match.Index : 0;
      }
    }
