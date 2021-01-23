    public static byte calculateLRC(byte[] bytes)
    {
        byte LRC = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
            LRC ^= bytes[i];
        }
        return LRC;
    }
