    foreach (var abGroup in groups)
    {
        int aKey = abGroup.Key.A;
        var bList = string.Join(",", abGroup.Select(x => x.Obj.B));
        Console.WriteLine("A = {0}, Bs = [ {1} ] ", aKey, bList);
    }
