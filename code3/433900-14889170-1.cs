    private static T CloneFull<T>(T i) {
        if (Object.ReferenceEquals(i, null)) return default(T);
        var x = new XmlSerializer(i.GetType());
        using (var m = new MemoryStream()) {
            x.Serialize(m, i);
            m.Seek(0, SeekOrigin.Begin);
            return (T)x.Deserialize(m);
        }
    }
