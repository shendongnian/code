    public static float sample()
    {
        int result = 154 + (153 << 8) + (25 << 16) + (64 << 24);
        return BitConverter.ToSingle(BitConverter.GetBytes(result), 0);
    }
