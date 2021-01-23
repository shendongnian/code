    public static string InsertHere(string source)
    {
      const int skip = 10;
      const int insertEvery = 3;
      var sb = new StringBuilder();
      using (var sr = new StringReader(source))
      {
        var buffera = new char[skip];
        var buffer = new char[insertEvery];
        sr.Read(buffera, 0, buffera.Length);
        sb.Append(buffera);
        while (sr.Peek() > 0)
        {
          sb.Append("[here]");
          sr.Read(buffer, 0, buffer.Length);
          sb.Append(buffer);
        }
      }   
      return sb.ToString();
    }
