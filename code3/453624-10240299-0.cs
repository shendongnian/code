            static public string DecodeFrom64(string encodedData)
            {
                byte[] encodedDataAsBytes
                    = System.Convert.FromBase64String(encodedData);
                string returnValue =
                   System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                return returnValue;
            }
    
            static public string EncodeTo64(string toEncode)
            {
                byte[] toEncodeAsBytes
                      = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
                string returnValue
                      = System.Convert.ToBase64String(toEncodeAsBytes);
                return returnValue;
            }
