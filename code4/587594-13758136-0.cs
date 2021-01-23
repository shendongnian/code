    public List<MyObject> DeepCopy()
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, this);
    
        ms.Position = 0;
        return (List<MyObject>) bf.Deserialize(ms);
    }
