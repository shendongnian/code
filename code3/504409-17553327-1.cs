    public IEnumerable<T> Deserialize<T>(string path)
    {
        using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
        {
            var item = Serializer.Deserialize<IEnumerable<T>>(stream);
            return item;
        }
    }
