    for (int i = 0; i < list[0].Count; i++)
    {
        var str0 = list[0][i];
        Console.WriteLine(str0);
        if (list[1].Count > i)
        {
            var str1 = list[1][i];
            Console.WriteLine(str1);
        }
    }
