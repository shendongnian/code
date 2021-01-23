    var int16List = List<Int16>();
    using (var stream = new FileStream(filename, FileMode.Open))
    using (var reader = new BinaryReader(stream))
    {
        while (!stream.AtEndOfStream())
        {
            int16List.Add(reader.ReadInt16());
        }
    }
    return int16List.ToArray();
