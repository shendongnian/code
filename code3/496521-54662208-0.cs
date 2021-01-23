    public static string GenSHA512(string s, bool l = false)
    {
        string r = "";
        try
        {
            byte[] d = Encoding.UTF8.GetBytes(s);
            using (SHA512 a = new SHA512Managed())
            {
                byte[] h = a.ComputeHash(d);
                r = BitConverter.ToString(h).Replace("-", "");
            }
            if (l)
                r = r.ToLower();
        }
        catch
        {
    
        }
        return r;
    }
