    public static byte[] FromBinaryString(string s)
    {
        int count = s.Length / 8;
        var b = new byte[c];
        for (int i = 0; i < count ; i++)
            b[i] = Convert.ToByte(s.Substring(i * 8, 8), 2);
        return b;
    }
