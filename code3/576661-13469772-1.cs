      var output = new List<string>(); // this holds the parameter lines
      var line = string.Empty;
      foreach (var c in str) // str holds the input string
      {
        if (c == '\n' || c == '\r') continue;
        line += c;
        if (c == '>')
        {
          output.Add(line);
          line = string.Empty;
        }
      }
