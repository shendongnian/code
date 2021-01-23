    //Client side encode
    static public string EncodeTo64(string toEncode)
    {
        byte[] toEncodeAsBytes
            = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        string returnValue
            = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
     
    //Server Side - Decode
    static public string DecodeFrom64(string encodedData)
    {
        byte[] encodedDataAsBytes
            = System.Convert.FromBase64String(encodedData);
        string returnValue =
            System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        return returnValue;
    }
    string data = "¦=¦=¦";
    data = HttpUtility.UrlEncode(EncodeTo64(data));
    data = DecodeFrom64(HttpUtility.UrlDecode(data));
