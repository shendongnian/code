    using (var file = File.OpenRead(filename))
    {
        var reader = new BinaryFormatter();
        data = (List<MyStructData>) reader.Deserialize(file); // Reads the entire list.
    }
    foreach (var item in data)
        Console.WriteLine("Id = {0}, Name = {1}", item.Id, item.Name);
