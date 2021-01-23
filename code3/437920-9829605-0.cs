      string dateStringsToValidate = "birthdatecake||birthdate||other||strings";
      string testValue = "strings";
      var result = WholeWordIndexOf(dateStringsToValidate, testValue);
    // ...
    public int WholeWordIndexOf(string source, string word, bool ignoreCase = false)
    {
      string testValue = "\\W?(" + word + ")\\W?";
      var regex = new System.Text.RegularExpressions
        .Regex(
          testValue,
          ignoreCase ? System.Text.RegularExpressions.RegexOptions.IgnoreCase : System.Text.RegularExpressions.RegexOptions.None);
      var match = regex.Match(source);
      return match.Captures.Count == 0 ? -1 : match.Groups[0].Index;
    }
