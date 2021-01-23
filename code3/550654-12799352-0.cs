    public static byte calculateLRC(byte[] bytes)
    {
        int LRC = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
            LRC += bytes[i];
        }
        return (byte)-LRC;
    }
