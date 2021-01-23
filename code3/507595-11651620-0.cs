    public static int GetMinByteSize(long value, bool signed)
    {
        ulong v = (ulong)value;
        // Invert the value when it is negative.
        if (signed && value < 0)
            v = ~v;
        // The minimum length is 1.
        int length = 1;
        // Is there any bit set in the upper half?
        // Move them to the lower half and try again.
        if ((v & 0xFFFFFFFF00000000) != 0)
        {
            length += 4;
            v >>= 32;
        }
        if ((v & 0xFFFF0000) != 0)
        {
            length += 2;
            v >>= 16;
        }
        if ((v & 0xFF00) != 0)
        {
            length += 1;
            v >>= 8;
        }
        // We have at most 8 bits left.
        // Is the most significant bit set (or cleared for a negative number),
        // then we need an extra byte for the sign bit.
        if (signed && (v & 0x80) != 0)
            length++;
        return length;
    }
