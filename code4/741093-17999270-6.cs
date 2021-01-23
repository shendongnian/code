    private string ReadString(BinaryReader reader, int length = 260)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; ++i)
        {
            byte b = reader.ReadByte();
            sb.Append((char)b);
        }
        return sb.ToString().Trim();
    }
