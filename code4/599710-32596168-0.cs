    public static string Encode(string input, byte[] key)
    {
        HMACSHA1 myhmacsha1 = new HMACSHA1(key);
        byte[] byteArray = Encoding.ASCII.GetBytes(input);
        MemoryStream stream = new MemoryStream(byteArray);
        return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
    }
