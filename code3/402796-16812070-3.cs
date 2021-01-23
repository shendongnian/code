    public static IEnumerable<string> JsonSplit(this StreamReader input, char openChar = '{', char closeChar = '}',
      char quote='"', char escape='\\')
    {
      var accumulator = new StringBuilder();
      int count = 0;
      bool gotRecord = false;
      bool inString = false;
      while (!input.EndOfStream)
      {
        char c = (char)input.Read();
        if (c == escape)
        {
          accumulator.Append(c);
          c = (char)input.Read();
        }
        else if (c == quote)
        {
          inString = !inString;
        }
        else if (inString)
        {
        }
        else if (c == openChar)
        {
          gotRecord = true;
          count++;
        }
        else if (c == closeChar)
        {
          count--;
        }
        accumulator.Append(c);
        if (count != 0 || !gotRecord) continue;
        // now we are not within a block so 
        string result = accumulator.ToString();
        accumulator.Clear();
        gotRecord = false;
        yield return result;
      }
    }
