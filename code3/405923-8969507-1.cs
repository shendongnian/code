    public static void WriteFile(ByteBuffer data, String fileName, bool append)
    {
        using(var writer = new StreamWriter(fileName, append))
        {
            writer.Write(data);
        }
    }
