    public static string DecodeFrom64(string value)
    {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(value);
        return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
    }
