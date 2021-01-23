    public static string Base64UrlEncode(byte[] bytes)
    {
        return Convert.ToBase64String(bytes).Replace("=", "").Replace('+', '-').Replace('/', '_');
    }
    public static byte[] Base64UrlDecode(string s)
    {
        s = s.Replace('-', '+').Replace('_', '/');
        string padding = new String('=', 3 - (s.Length + 3) % 4);
        s += padding;
        return Convert.FromBase64String(s);
    }
