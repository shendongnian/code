    public static class Extensions
    {
      public static string RemoveEnd(this string strBefore, string substringToRemove)
      {
        if (!strBefore.EndsWith(substringToRemove))
          return strBefore;
        return strBefore.Remove(strBefore.Length - substringToRemove.Length);
      }
    }
