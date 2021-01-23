    var int16List = List<Int16>();
    using (var stream = new FileStream(filename, FileMode.Open))
    using (var reader = new BinaryReader(stream))
    {
        try
        {
            while (true)
                int16List.Add(reader.ReadInt16());
        }
        catch (EndOfStreamException ex)
        {
            // We've read the whole file
        }
    }
    return int16List.ToArray();
