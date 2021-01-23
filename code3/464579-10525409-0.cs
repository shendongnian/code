    public static string SplitAndReJoin(string str, char[] delimiters, 
      Func<string[], string[]> mutator)
    {
      //first thing to know is which of the delimiters are 
      //actually in the string, and in what order
      //Using ToArray() here to get the total count of found delimiters
      var delimitersInOrder = (from ci in
                                (from c in delimiters
                                 from i in FindIndexesOfAll(str, c)
                                 select new { c, i })
                              orderby ci.i
                              select ci.c).ToArray();
      if (delimitersInOrder.Length == 0)
        return str;
      //now split and mutate the string
      string[] strings = str.Split(delimiters);
      strings = mutator(strings);
      //now build a format string
      //note - this operation is much more complicated if you wish to use 
      //StringSplitOptions.RemoveEmptyEntries
      string formatStr = string.Join("",
        delimitersInOrder.Select((c, i) => string.Format("{{{0}}}", i)
          + c));
      if (strings.Length > delimitersInOrder.Length)
        formatStr += string.Format("{{{0}}}", strings.Length - 1);
      
      return string.Format(formatStr, strings);
    }
    public static IEnumerable<int> FindIndexesOfAll(string str, char c)
    {
      int startIndex = 0;
      int lastIndex = -1;
      while(true)
      {
        lastIndex = str.IndexOf(c, startIndex);
        if (lastIndex != -1)
        {
          yield return lastIndex;
          startIndex = lastIndex + 1;
        }
        else
          yield break;
      }
    }
