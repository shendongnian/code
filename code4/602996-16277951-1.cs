    private T ConvertFromBase64String<T>(string string64) where T : IBinarySerializable, new()
    {
        if (string.IsNullOrEmpty(string64))
            return default(T);
        var bytes = System.Convert.FromBase64String(string64);
        using (var stream = new System.IO.MemoryStream(bytes))
        using (var reader = new System.IO.BinaryReader(stream))
        {
            var obj = new T();
            obj.Read(reader);
            return obj;
        }
    }
