     public string Encode(string text)
        {
            
            byte[] myASCIIBytes = UnicodeEncoding.Unicode.GetBytes(text);
            byte[] myUTF8Bytes = Encoding.Convert( Encoding.Unicode,UTF8Encoding.UTF8, myASCIIBytes);
            
            return Encoding.Default.GetString(myUTF8Bytes);
        }
    protected string UrlEncodePost(string value)
        {
            StringBuilder result = new StringBuilder();
           
            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }
            return result.ToString();
        }
       timeZone = UrlEncodePost(Encode("Central Time (US & Canada)"));
