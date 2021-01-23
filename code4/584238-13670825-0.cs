    public static string EncodeTo64(this string target)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(target);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
       
    public static string DecodeFrom64(this string target)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(target);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
