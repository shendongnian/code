    public static Stream FillWithPadding(Stream MS, int Count)
    {
        byte[] buffer = new byte[64];
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = 0xFF;
        }
        MS.Position = 0;
        while (Count > buffer.Length)
        {
            MS.Write(buffer, 0, buffer.Length);
            Count -= buffer.Length;
        }
        MS.Write(buffer, 0, Count);
        return MS;
    }
