    IEnumerable<string> UnindentAsMuchAsPossible(string[] content)
    {
      int minIndent = content.Select(s => s.TakeWhile(c => c == ' ').Count()).Min();
      return content.Select(s => s.Substring(minIndent)).AsEnumerable();
    }
