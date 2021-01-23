    for (int i = 0; i < 5; i++)
    {
        foreach (var pipe in _pipes)
        {
            pipe.Value.Add(
                new TestObject { Name = DateTime.Now.ToString("o") + "-" + i });
        }
    }
