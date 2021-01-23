        var patterns = new Dictionary<string, string>();
        patterns["_Date"] = profileConfig.SelectedMonth.ToString("MMMM yyyy");
        patterns["_Name"] = profileConfig.Name;
        var builder = new StringBuilder(template.Length);
        for (var i = 0; i < template.Length;)
        {
          var pattern = CompareAndFindPattern(template, i, patterns);
          if (pattern != null)
          {
            builder.Append(pattern.Value.Value);
            i += pattern.Value.Key.Length;
          }
          else
          {
            builder.Append(template[i]);
            i++;
          }
        }
      static KeyValuePair<string, string>? CompareAndFindPattern(string template, int index, Dictionary<string, string> patterns)
      {
        foreach (var pattern in patterns)
        {
          if (string.Compare(template, index, pattern.Key, 0, pattern.Key.Length) == 0)
            return pattern;
        }
        return null;
      }
