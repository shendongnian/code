    public static byte[] GetAsciiBytesEvenParity(this string text)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(text);
    
        for(int ii = 0; ii < bytes.Length; ii++)
        {
            // parity test adapted from: 
            // http://graphics.stanford.edu/~seander/bithacks.html#ParityParallel
            if (((0x6996 >> ((bytes[ii] ^ (bytes[ii] >> 4)) & 0xf)) & 1) != 0)
            {
                bytes[ii] |= 0x80;
            }
        }
        
        return bytes;
    }
