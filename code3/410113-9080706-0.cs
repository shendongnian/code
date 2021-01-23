    var formatter = new BinaryFormatter();
    // Serialize
    using (var stream = File.OpenWrite(path))
    {
        formatter.Serialize(stream, yourObject);
    }
    ...
    // Deserialize
    using (var stream = File.OpenRead(path))
    {
        YourType yourObject = (YourType)formatter.Deserialize(stream);
    }
