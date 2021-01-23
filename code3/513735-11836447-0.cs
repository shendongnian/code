    public static int ReverseEndianness(int num)
    {
        byte[] bytes = BitConverter.GetBytes(num);
        byte[] reversedBytes = new byte[bytes.Length];
    
        for (int i = 0; i < bytes.Length; i++)
        {
            reversedBytes[i] = bytes[bytes.Length - 1 - i];
        }
    
        return BitConverter.ToInt32(reversedBytes, 0);
    }
