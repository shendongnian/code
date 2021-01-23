    byte[] ObjectToByteArray(Object obj)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
