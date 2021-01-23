    public static byte[] FromBinaryString(string s)
    {
        int count = s.Length / 8;
        var b = new byte[count];
        for (int i=0; i<count; i++)
            b[i] = Convert.ToBYte(s.Substring(i * 8, 8), 2);
        return b;
    }
