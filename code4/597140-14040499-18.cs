    BinaryFormatter ser = new BinaryFormatter();
    using(MemoryStream ms = new MemoryStream(clearContent))
    {
        List<FileEntry>  files = ser.Deserialize(ms) as List<FileEntry>;
    }
