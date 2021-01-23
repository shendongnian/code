    for (int i = 0; i < 3; ++i)
    {
        List<int> tl = new List<int>();
        tl.Add(5);
        tl.Add(4);
        using (var fileStream = new FileStream(@"C:\file.dat", FileMode.Append))
        {
            Serializer.Serialize(fileStream, tl);
        }
        using (var fileStream = new FileStream(@"C:\file.dat", FileMode.Open))
        {
            list = Serializer.Deserialize<List<int>>(fileStream);
        }
    }
