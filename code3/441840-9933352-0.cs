    int WordCount(string text)
    {
      var regex = new System.Text.RegularExpressions.Regex(@"\w+");
      var matches = regex.Matches(text);
      return matches.Count;     
    }
