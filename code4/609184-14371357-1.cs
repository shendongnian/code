      static readonly Regex lineRegex = new Regex(@"(?<Field1>[\w\s]+)\s*,\s*(?<Field2>[\w\s]+)\s*,\s*(?<Number>\d{4})");
      // You should define your own class which has these fields and out
      // that as a single object instead of these three separate fields.
      public static bool TryParse(string line, out string field1,
                                               out string field2, 
                                               out int number)
      {
        field1 = null;
        field2 = null;
        number = 0;
        var match = lineRegex.Match(line);
        // Does not match the pattern, cannot parse.
        if (!match.Success) return false;
        field1 = match.Groups["Field1"].Value;
        field2 = match.Groups["Field2"].Value;
        // Try to parse the integer value.
        if (!int.TryParse(match.Groups["Number"].Value, out number))
          return false;
        return true;
      }
