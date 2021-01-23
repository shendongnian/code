    private static IEnumerable<string> InclusiveSplit
    (
        string source, 
        string pattern
    )
    {
      List<string> parts = new List<string>();
      int currIndex = 0;
      // First, find all the matches. These are your separators.
      MatchCollection matches = 
          Regex.Matches(source, pattern, 
          RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
      foreach (Match match in matches)
      {
        // If the match begins after our current index, we need to add the
        // portion of the source string between the last match and the 
        // current match.
        if (match.Index > currIndex)
        {
          parts.Add(source.Substring(currIndex, match.Index - currIndex));
        }
        // Add the matched value, of course, to make the split inclusive.
        parts.Add(match.Value);
        // Update the current index so we know if the next match has an 
        // unmatched substring before it.
        currIndex = match.Index + match.Length;
      }
      // Finally, check is there is a bit of unmatched string at the end of the 
      // source string.
      if (currIndex < source.Length)
        parts.Add(source.Substring(currIndex));
      return parts;
    }
