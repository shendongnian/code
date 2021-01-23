    var dt = new DataTable();
    dt.Load(yourDataReader);
    //... any access tests
    dt.RemotingFormat = SerializationFormat.Binary;
    using (var file = File.Create(path))
    {
        var bf = new BinaryFormatter();
        bf.Serialize(file, dt);
    }
    // ... also check deserialize, if that is perf-critical
