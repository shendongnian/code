    public static byte[] StringToBytes(string str)
    {
        var bytes = new byte[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            bytes[i] = checked((byte)str[i]); // Slower but throws OverflowException if there is an invalid character
            //bytes[i] = unchecked((byte)str[i]); // Faster
        }
        return bytes;
    }
