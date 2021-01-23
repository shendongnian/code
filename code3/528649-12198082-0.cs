    public static int CompareString(string Left, string Right, bool TextCompare)
    {
      if (Left == Right)
        return 0;
      if (Left == null)
        return Right.Length == 0 ? 0 : -1;
      else if (Right == null)
      {
        return Left.Length == 0 ? 0 : 1;
      }
      else
      {
        int num = !TextCompare 
           ? string.CompareOrdinal(Left, Right) 
           : Utils.GetCultureInfo().CompareInfo
                  .Compare(Left, Right, CompareOptions.IgnoreCase 
                                      | CompareOptions.IgnoreKanaType 
                                      | CompareOptions.IgnoreWidth);
        if (num == 0)
          return 0;
        return num > 0 ? 1 : -1;
      }
    }
