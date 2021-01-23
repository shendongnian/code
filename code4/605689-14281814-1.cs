    public void Create(string Filename, string BaseExecutable)
    {
        FileStream Source = new FileStream(BaseExecutable, FileMode.Open, FileAccess.Read, FileShare.Read);
        file = new FileStream(Filename, FileMode.Create, FileAccess.Write, FileShare.None);
        byte[] buffer = new byte[65536];
        Source.Read(buffer, 0, 48);
        file.Write(buffer, 0, 44);
        writer = new BinaryWriter(file, Encoding.ASCII);
        writer.Write((uint)Source.Length);
        int count;
        while ( (count=Source.Read(buffer, 0, buffer.Length))>0)
            file.Write(buffer, 0, count);
    }
