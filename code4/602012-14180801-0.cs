    static bool EqualsExceptOneExtraChar(string goodStr, string strWithOneExtraChar)
    {
      if (strWithOneExtraChar.Length != goodStr.Length + 1)
        return false;
      for (int i = 0; i < strWithOneExtraChar.Length; ++i)
      {
        if (strWithOneExtraChar.Remove(i, 1) == goodStr)
          return true;
      }
      return false;
    }
