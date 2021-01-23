    public static string HexToString(string hex)
    {
      var buffer = new byte[hex.Length / 2];
      for(int i = 0; i < hex.Length; i+=2)
      {
        string hexdec = hex.Substring(i, 2);
        buffer[i / 2] = byte.Parse(hexdec, NumberStyles.HexNumber);
      }
      return Encoding.UTF8.GetString(buffer);//we could even have passed this encoding in for greater flexibility.
    }
