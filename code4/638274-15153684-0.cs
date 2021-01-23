    static void BraceMatch(string text)
    {
      int level = 0;
      foreach (char c in text)
      {
        if (c == '(')
        {
          // opening brace detected
          level++;
        }
        if (c == ')')
        {
          level--;
          if (level < 0)
          {
            // closing brace detected, without a corresponding opening brace
            throw new ApplicationException("Opening brace missing.");
          }
        }
      }
      if (level > 0)
      {
        // more open than closing braces
        throw new ApplicationException("Closing brace missing.");
      }
    }
