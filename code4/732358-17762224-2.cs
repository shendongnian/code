    static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
    
    public static int NextRandomDigit() {
      Byte[] bytes = new Byte[1];
    
      while (true) {
        provider.GetBytes(bytes);
    
        // since GetBytes returns value in a range of [0..255], we should skip [250..255]
        // in order to value % 10 being uniformly distributed
        if (bytes[0] >= 250)
          continue;
    
        return bytes[0] % 10;
      }
    }
    
    // Constructing long digit by digit
    // Assuming that numberOfDigits is small enough (18 or less) 
    // for returning value being of type long
    public static long NextRandomLong(int numberOfDigits) {
      long result = 0;
    
      for (int i = 0; i < numberOfDigits; ++i)
        result = result * 10 + NextRandomDigit();
    
      return result;
    }
    
    // Constructing number in String representation digit by digit
    public static String NextRandomString(int numberOfDigits) {
      StringBuilder Sb = new StringBuilder();
    
      for (int i = 0; i < numberOfDigits; ++i)
        Sb.Append((Char) ('0' + NextRandomDigit()));
    
      return Sb.ToString();
    }
