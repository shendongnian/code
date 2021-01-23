     public static string Convert(string s)
    {
      var ret = new StringBuilder((int) (71 + (s.Length * 1.1)));
      ret.Append(@"{\rtf1\ansi\ansicpg1250\deff0{\fonttbl\f0\fswiss Helvetica;}\f0\pard ");
      foreach (var letter in s)
      {
        switch (letter)
        {
          case '\\':
          case '{':
          case '}':
            ret.Append('\\');
            break;
          case '\r':
            ret.Append("\\par");
            break;
        }
        ret.Append(letter);
      }
      ret.Append(" }");
      return ret.ToString();
    }
