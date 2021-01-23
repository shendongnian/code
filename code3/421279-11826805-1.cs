    public static string InterpretAsUTF8(string value)
    {
      byte[] rawData = Encoding.Default.GetBytes(value);
      string reencoded = Encoding.UTF8.GetString(rawData);
      return reencoded;
    }
