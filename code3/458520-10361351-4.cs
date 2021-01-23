    public URL DeepClone()
    { 
        MemoryStream m = new MemoryStream();
        BinaryFormatter b = new BinaryFormatter();
        b.Serialize(m, this);
        m.Position = 0;
        return (URL)b.Deserialize(m);
    }
