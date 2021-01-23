    private static string NormalizeSearchPattern(string searchPattern)
    {
      string searchPattern1 = searchPattern.TrimEnd(Path.TrimEndChars);
      if (searchPattern1.Equals("."))
        searchPattern1 = "*";
      Path.CheckSearchPattern(searchPattern1);
      return searchPattern1;
    }
