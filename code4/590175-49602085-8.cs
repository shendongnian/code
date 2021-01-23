    public static String PercentEncode(string textToEncode)
    {
    
        return string.IsNullOrEmpty(textToEncode)
            ?""
            : UrlEncoder.Default.Encode(Cardinity.ENCODING.GetString(Cardinity.ENCODING.GetBytes(textToEncode)))
                .Replace("+", "%20").Replace("*", "%2A")
                .Replace("%7E", "~");
    
    }
