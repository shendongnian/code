    var list = new List<string>();
    using (var reader = new StreamReader(fileName))
    {
        for (int i = 0; i < 10; i++)
        {
            list.Add(reader.ReadLine());
        }
    }
    return list;
