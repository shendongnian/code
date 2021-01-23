    public static int GetRandom(RNGCryptoServiceProvider rngProvider, int min, int max)
    {
        byte[] b = new byte[sizeof(UInt32)];
        rngProvider.GetBytes(b);
        double d = BitConverter.ToUInt32(b, 0) / (double)UInt32.MaxValue;
        return min + (int)((max - min) * d);
    }
