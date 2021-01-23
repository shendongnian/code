    private void save()
    {
        BitArray bits = new BitArray(164, true);
        byte[] bytes = new byte[21]; // 21 * 8 bits = 168 bits (last 4 bits are unused)
        bits.CopyTo(bytes, 0);
        for (int i = 0; i < 21; i++)
        {
            bytes[i] = ToByte(bits, i);
        }
        // now save your byte array to file
    }
    private byte ToByte(BitArray bits, int start) 
    {
        int sum = 0;
        if (bits[start])
            sum += 8;
        if (bits[start + 1])
            sum += 4;
        if (bits[start + 2])
            sum += 2;
        if (bits[start + 3])
            sum += 1;
        return Convert.ToByte(sum);
    }
