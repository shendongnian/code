    void Write<T>(string fileName, T obj)
    {
        using (var stream = File.Create(fileName))
        {
            Write(stream, obj);
        }
    }
    T Read<T>(string fileName)
    {
        using (var stream = File.Open(fileName, FileMode.Open))
        {
            return Read<T>(stream);
        }
    }
