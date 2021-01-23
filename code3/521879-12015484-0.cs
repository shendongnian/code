    public static void Write(this BinaryWriter source, IEnumerable<int>items) {
        foreach (var item in items)
            source.Write(item);
    }
    public static void Write(this BinaryWriter source, IEnumerable<double>items) {
        foreach (var item in items)
            source.Write(item);
    }
    public static void Write(this BinaryWriter source, IEnumerable<byte>items) {
        foreach (var item in items)
            source.Write(item);
    }
