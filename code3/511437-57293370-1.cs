    public static string ToBase64(string s)
    {
        byte[] buffer = System.Text.Encoding.Unicode.GetBytes(s);
        return System.Convert.ToBase64String(buffer);
    }
