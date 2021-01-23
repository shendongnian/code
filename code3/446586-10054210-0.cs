    void Save(SomeType obj, string fileName)
    {
        using (var stream = File.OpenWrite(fileName))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
        }
    }
