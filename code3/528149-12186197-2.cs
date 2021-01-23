    public static string HexToString(string hex)
    {
      var sb = new StringBuilder();//to hold our result;
      for(int i = 0; i < hex.Length; i+=2)//chunks of two - I'm just going to let an exception happen if there is an odd-length input, or any other error
      {
        string hexdec = hex.Substring(i, 2);//string of one octet in hex
        int number = int.Parse(hexdec, NumberStyles.HexNumber);//the number the hex represented
        char charToAdd = (char)number;//coerce into a character
        sb.Append(charToAdd);//add it to the string being built
      }
      return sb.ToString();//the string we built up.
    }
