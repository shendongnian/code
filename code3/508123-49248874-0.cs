    public static unsafe void Swap4(byte[] source)
    {
        fixed (byte* psource = source)
        {
            var length = (source.Length & 0xFFFFFFFC);
            while (length > 7)
            {
                length -= 8;
                ulong* pulong = (ulong*)(psource + length);
                *pulong = ( ((*pulong >> 24) & 0x000000FF000000FFUL)
                          | ((*pulong >> 8)  & 0x0000FF000000FF00UL)
                          | ((*pulong << 8)  & 0x00FF000000FF0000UL)
                          | ((*pulong << 24) & 0xFF000000FF000000UL));
            }
            if(length != 0)
            {
                uint* puint = (uint*)psource;
                *puint = ( ((*puint >> 24))
                         | ((*puint >> 8) & 0x0000FF00U)
                         | ((*puint << 8) & 0x00FF0000U)
                         | ((*puint << 24)));
            }
        }
    }
