    public static string DecodeBase64EncodedString(string s, Encoding encoder = null)
    {
        if (encoder == null)
            encoder = Encoding.Default;
        //return System.Text.Encoding.Default.GetString(bytes);
        byte[] bytes = Convert.FromBase64String(s);
        return encoder.GetString(bytes);
    }
