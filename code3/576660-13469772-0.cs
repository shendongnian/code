      var output = new List<string>();
      var line = string.Empty;
      foreach (var c in str)
      {
        if (c == '\n' || c == '\r') continue;
        line += c;
        if (c == '>')
        {
          output.Add(line);
          line = string.Empty;
        }
      }
