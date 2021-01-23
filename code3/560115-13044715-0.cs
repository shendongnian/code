    public static float ReadSingleBigEndian(byte[] data, int offset)
    {
        return ReadSingle(data, offset, false);
    }
    public static float ReadSingleLittleEndian(byte[] data, int offset)
    {
        return ReadSingle(data, offset, true);
    }
    private static float ReadSingle(byte[] data, int offset, bool littleEndian)
    {
        if (BitConverter.IsLittleEndian != littleEndian)
        {
            byte tmp = data[offset];
            data[offset] = data[offset + 3];
            data[offset + 3] = tmp;
            tmp = data[offset + 1];
            data[offset + 1] = data[offset + 2];
            data[offset + 2] = tmp;
        }
        return BitConverter.ToSingle(data, offset);
    }
