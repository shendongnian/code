    public void WriteTo(BinaryWriter writer)
    {
        writer.Flush();
        this.memoryStream.CopyTo(writer.BaseStream);
    }
