    static public string EncodeTo64(string toEncode) {
        var e = Encoding.GetEncoding("iso-8859-1");
        byte[] toEncodeAsBytes = e.GetBytes(toEncode);
        string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
    static public string DecodeFrom64(string encodedData) {
        var e = Encoding.GetEncoding("iso-8859-1");
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        string returnValue = e.GetString(encodedDataAsBytes);
        return returnValue;
    }
