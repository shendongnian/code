    static public string EncodeTo64(string toEncode) {
        byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
    static public string DecodeFrom64(string encodedData) {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        return returnValue;
    }
    MessageBox.Show(DecodeFrom64("aHR0cDovL3d3dy5pbWRiLmNvbS90aXRsZS90dDA0MDE3Mjk="));
