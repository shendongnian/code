    public static string DecodeFrom64(this string encodedData)
    {
        var data = Convert.FromBase64String(encodedData);
        string result = System.Text.ASCIIEncoding.ASCII.GetString(data);
        return result;
    }
