      static public string DecodeFrom64(string encodedData)
      {
         byte[] encodedDataAsBytes
             = Convert.FromBase64String(encodedData);
         string returnValue =
            Encoding.ASCII.GetString(encodedDataAsBytes);
         return returnValue;
      }
