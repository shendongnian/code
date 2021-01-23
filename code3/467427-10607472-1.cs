    static List<string> letters = new List<string> { "x", "y", };
    static List<string> MakeList(int input)
    {
      if (input < 0)
        throw new ArgumentOutOfRangeException();
      var li = new List<string> { "", };
      for (int i = 0; i < input; ++i)
        li = Multiply(li);
      return li;
    }
    static List<string> Multiply(List<string> origList)
    {
      var resultList = new List<string>(origList.Count * letters.Count);
      foreach (var letter in letters)
        resultList.AddRange(origList.Select(s => letter + s));
      return resultList;
    }
