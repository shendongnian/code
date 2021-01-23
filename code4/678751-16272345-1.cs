    static bool DuplicatesHaveSameCasing(string[] strings)
    {
      for (int i = 0; i < strings.Length; ++i)
      {
        for (int j = i + 1; j < strings.Length; ++j)
        {
          if (string.Equals(strings[i], strings[j], StringComparison.OrdinalIgnoreCase)
            && strings[i] != strings[j])
          {
            return false;
          }
        }
      }
      return true;
    }
