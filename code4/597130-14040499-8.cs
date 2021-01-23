    BinarryFormatter ser = new BinarryFormatter();
    using(MemoryStram ms = new MemoryStram(clearContent))
    {
        List<FileEntry>  files = ser.DeSerialize(ms) as List<FileEntry>;
    }
