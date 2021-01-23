    private static long ConvertAsciiBytesToInt32(byte[] bytes)
    {
        long value = 0;
        foreach (byte b in bytes)
        {
            value *= 10L;
            char c = b; // Implicit conversion; effectively ISO-8859-1
            if (c < '0' || c > '9')
            {
                throw new ArgumentException("Bytes contains non-digit: " + c);
            }
            value += (c - '0');
        }
        return value;
    }
