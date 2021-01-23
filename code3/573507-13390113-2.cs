    public static string ReadNT(BinaryReader stream)
    {
        List<byte> bytes = new List<byte>();
        byte addByte = 0x00;
        do
        {
            addByte = ReadByte(stream);
            if (addByte != 0x00)
            {
                bytes.Add((char)addByte);
            }
        } while (addByte != 0x00);
        return Encoding.UTF8.GetString(bytes.ToArray());
    }
