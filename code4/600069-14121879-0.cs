    static string Int32ToBigEndianHexByteString(Int32 i)
    {
        byte[] bytes = BitConverter.GetBytes(i);
        if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
        return String.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}",
            bytes[0], bytes[1], bytes[2], bytes[3]);
    }
