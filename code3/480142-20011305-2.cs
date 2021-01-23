    // http://stackoverflow.com/a/829994/346561
    public static byte[] UnsignedBytesFromSignedBytes(sbyte[] signed)
    {
        var unsigned = new byte[signed.Length];
        Buffer.BlockCopy(signed, 0, unsigned, 0, signed.Length);
        return unsigned;
    }
