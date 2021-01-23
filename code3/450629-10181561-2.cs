    static void Main(string[] args)
    {
        byte[] dataPacket = { 0x78, 0x78, 0x0D, 0x01, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45, 0x00, 0x01, 0x8C, 0xDD, 0x0D, 0x0A };
        var crc16 = GetCrc16(dataPacket, 2, 12);
        if (crc16 == flipEndian(BitConverter.ToUInt16(dataPacket, 14)))
        {
            Debugger.Break();
            //use packet.
        }
        Debugger.Break();
    }
    public static ushort flipEndian(ushort value)
    {
        var bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }
    public static ushort GetCrc16(byte[] data, int offset, int length)
    {
        ushort fcs = 0xFFFF;
        for (int i = offset; i < length + offset; i++)
        {
            fcs = (ushort)((ushort)(fcs >> 8) ^ crctab16[(fcs ^ data[i]) & 0xFF]);
        }
        return (ushort)(~fcs);
    }
    public static bool IsCrcITUGood(byte[] data, int offset, int length)
    {
        ushort fcs = 0xFFFF;
        for (int i = offset; i < length + offset; i++)
        {
            fcs = (ushort)((ushort)(fcs >> 8) ^ crctab16[(fcs ^ data[i]) & 0xFF]);
        }
        return (fcs == 0xF0B8); //magic value
    }
    static ushort[] crctab16 = /*(snip)*/;
