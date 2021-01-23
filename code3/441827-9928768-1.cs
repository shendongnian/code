    public static string NormalizeFileName(string input) {
      var invalid = Path.GetInvalidPathChars();
      var builder = new System.Text.StringBuilder();
      foreach(char c in input) {
        if (invalid.Contains(c)) {
          builder.Append('_');
        } else {
          builder.Append(c);
        }
      }
      return builder.ToString();
    }
