    var serializer = new DataContractSerializer(typeof(TestClass));
    using (var stream = new MemoryStream())
    {
        serializer.WriteObject(stream, this);
        File.WriteAllBytes("TestClass.xml", stream.ToArray());
    }
    TestClass o = null;
    using (var stream = new MemoryStream(File.ReadAllBytes("TestClass.xml")))
    {
        o = serializer.ReadObject(stream) as TestClass;
    }
