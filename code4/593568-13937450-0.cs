    public BigInteger CreateUnsignedBigInteger(byte[] bytes)
    {
        if ((bytes[bytes.Length - 1] & 0x80) > 0) 
        {
            byte[] old = bytes;
            bytes = new byte[old.Length + 1];
            Array.Copy(old, bytes, old.Length);
        }
        return new BigInteger(bytes);
    }
