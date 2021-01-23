    public byte[] GetBytes()
    {
    MemoryStream fs = new MemoryStream();
    TextWriter tx = new StreamWriter(fs);
    tx.WriteLine("1111");
    tx.WriteLine("2222");
    tx.WriteLine("3333");
    tx.Flush();
    fs.Flush();
    byte[] bytes = fs.ToArray();
    return bytes;
    }
