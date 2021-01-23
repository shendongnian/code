    var tdp = new DerivedObject("Test");
    using (var ms  = new MemoryStream())
    {
        JsonSerializer.Serialize(ms,tdp); //should be protobuf
        ms.Seek(0, SeekOrigin.Begin);
        var tdp2 = Serializer.Deserialize<DerivedObject>(ms);
    }
