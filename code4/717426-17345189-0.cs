    static string Sha1(string password)
    {
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder sb = new StringBuilder();
        foreach (byte b in data)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
    static string RandomKey(uint amaunt)
    {
        const string keyset = "abcdefghijklmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder((int)amaunt, (int)amaunt);
        Random rnd = new Random();
        for (uint i = 0; i < amaunt; i++)
            sb.Append(keyset[rnd.Next(keyset.Length)]);
        return sb.ToString();
    }
