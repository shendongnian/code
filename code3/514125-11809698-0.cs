    public static string EncodeTo64(string toEncode)
    {
       byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
       return Convert.ToBase64String(toEncodeAsBytes);
    }
    public static string DecodeFrom64(string encodedData)
    {
      byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
      return Encoding.ASCII.GetString(encodedDataAsBytes);
    }
