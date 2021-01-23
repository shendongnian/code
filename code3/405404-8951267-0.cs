    public static bool StartsWith(Stream stream this, string value)
    {
      using(reader = new StreamReader(stream))
      {
        string str = reader.ReadToEnd();
        return str.StartsWith(value);
      }
    }
