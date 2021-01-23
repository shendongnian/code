    public static byte[] BitArrayToByteArray(BitArray bits)
    {
        byte[] bytes = new byte[bits.Length / 8];
        // Fill the array with 0xFF to illustrate.
        for (int i = 0; i < bytes.Length; ++i)
        {
            bytes[i] = 0xFF;
        }
        bits.CopyTo(bytes, 0);
        return bytes;
    }
