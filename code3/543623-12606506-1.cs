    public static string ByteArrayToHexString(byte[] p)
    {
        byte b;
        char[] c = new char[p.Length * 2 + 2];
        c[0] = '0'; c[1] = 'x';
        for (int y = 0, x = 2; y < p.Length; ++y, ++x)
        {
            b = ((byte)(p[y] >> 4));
            c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            b = ((byte)(p[y] & 0xF));
            c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
        }
        return new string(c);
    }
