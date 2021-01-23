    private void SerializeObjects(List<foo> foos, Stream stream)
    {
        foreach (var f in foos)
        {
            stream.Write(f);
        }
    }
    
    private void DeserializeObjects(List<foo> foos, Stream stream)
    {
        foo f = stream.ReadFoo();
        while (f != null)
        {
            foos.Add(f);
            f = stream.ReadFoo();
        }
    }
