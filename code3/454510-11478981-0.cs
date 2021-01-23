    static public string EncodeTo64(string toEncode)
      {
         byte[] toEncodeAsBytes
               = Encoding.ASCII.GetBytes(toEncode);
         string returnValue
               = Convert.ToBase64String(toEncodeAsBytes);
         return returnValue;
      }
