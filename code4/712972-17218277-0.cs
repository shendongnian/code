    using (BinaryReader writer = new BinaryWrite(File.OpenWrite("target"))
    {
        using (BinaryReader reader = new BinaryReader(File.OpenRead("source"))
        {
            var nextChar = reader.Read();
            while (nextChar != -1)
            {
                writer.Write(Convert.ToChar(nextChar));
                nextChar = reader.Read();
            }
        }
    }
