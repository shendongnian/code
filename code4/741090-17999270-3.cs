    private string ReadString(BinaryReader reader, int length = 260)
    {
        byte b;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; ++i)
        {
            sb.Append((char)b);
        }
        return sb.ToString().Trim();
    }
