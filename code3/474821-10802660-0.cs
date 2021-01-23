    Parallel.Invoke(
        () =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                dict1.Add(i, "Test" + i);
            }
        },
        () =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                dict2.Add(i, "Test" + i);
            }
        }
    );
