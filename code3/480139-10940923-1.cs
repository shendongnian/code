    public void parse_table(BinaryReader inFile)
    {
        byte[] idstring = inFile.ReadBytes(6);
        Console.WriteLine(Encoding.UTF8.GetString(idstring));
    }
