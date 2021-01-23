    using (var file = File.Create(path)) // or append file FileStream etc
    using (var writer = new BinaryWriter(file))
    {
        for (long i = 0; i < 10000; i++)
        {
            writer.Write(i);
            writer.Write(true);
            writer.Write(false);
        }
    }
