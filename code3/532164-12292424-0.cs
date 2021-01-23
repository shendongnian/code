    byte[] bytes = ...
    if ((bytes[bytes.Length - 1] & 0x80) != 0)
    {
        Array.Resize<byte>(ref bytes, bytes.Length + 1);
    }
    BigInteger result = new BigInteger(bytes);
