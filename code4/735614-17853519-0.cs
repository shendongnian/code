    return Task.Factory.StartNew(()=>
        decimal result = 0;
        for (int n = 1; n < 100000000; n++)
        {
            result += n;
        }
        Console.WriteLine(result);
    });
