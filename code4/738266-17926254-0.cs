    public void ReadBytes(byte[] data)
    {
        fixed (byte* ptr = ByteArray)
        {
            for (int i = 0; i < 16; i++)
                data[i] = ptr[i];
        }
    }
