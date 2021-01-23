    int batchsize = 5;
    List<string> colection = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
    for (int x = 0; x < Math.Ceiling((decimal)colection.Count / batchsize); x++)
    {
        var t = colection.Skip(x * batchsize).Take(batchsize);
    }
