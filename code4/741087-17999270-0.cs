    using (var fs = File.OpenRead(filename))
    {
        using (var reader = new BinaryReader(fs))
        {
            // reading happens here
        }
    }
    private string ReadString(BinaryReader reader)
    {
        byte b;
        StringBuilder sb = new StringBuilder();
        while ((b = reader.ReadByte()) != 0)
        {
            sb.Append((char)b);
        }
        return sb.ToString();
    }
