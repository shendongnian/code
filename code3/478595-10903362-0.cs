    BinaryFormatter formatter = new BinaryFormatter();
    using (MemoryStream m = new MemoryStream())
    {
        formatter.Serialize(m, list);
        m.Position = 0;
        StreamReader sr = new StreamReader(m);
        HiddenField1.Value = sr.ReadToEnd();
    }
