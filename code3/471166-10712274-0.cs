      Matches matches = re.Matches("Hey, this is an example string. A string is a collection of characters.");
      StringBuilder sb = new StringBuilder();
      foreach (Match m in matches)
      {
          sb.Append(m.Groups[1].Value);
      }
