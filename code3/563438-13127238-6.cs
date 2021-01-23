    public static byte[] FromBinaryString(string s)
    {
        int c = s.Length / 8;
        var b = new byte[c];
        for (int i = 0; i < c; i++)
            b[i] = Convert.ToByte(s.Substring(i * 8, 8), 2);
        return b;
    }
