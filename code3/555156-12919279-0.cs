    public static T CloneBySerialization<T>(this T source) where T : EntityObject {
        var serializer = new DataContractSerializer(typeof(T));
        using (var ios = new MemoryStream()) {
            serializer.WriteObject(ios, source);
            ios.Seek(0, SeekOrigin.Begin);
            return ((T) serializer.ReadObject(ios));
        }
    }
