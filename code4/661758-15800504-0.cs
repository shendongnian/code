      string pattern = @"\s*FROM\s+Table\.dbo\.(\w+)\s+(\w+)";
      string input = "line from stored proc body here";
      MatchCollection matches = Regex.Matches(input, pattern);
      foreach (Match match in matches)
      {
         Console.WriteLine("table name:       {0}", match.Groups[1].Value);
         Console.WriteLine("Alias:            {0}", match.Groups[2].Value);
         Console.WriteLine();
      }
