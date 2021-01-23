    // Scenario 1
    //send collection numberBlock-times
    var input = new List<List<Object1>>(numberBlocks);
    for (int i = 0; i < numberBlocks; i++)
    {
        var list = new List<Object1>(collectionSize);
        for (int j = 0; j < collectionSize; j++)
        {
            list.Add(new Object1(j));
        }
        input.Add(list);
    }
    foreach (var inp in input)
    {
        broadCastBlock.Post(inp);
        Thread.Sleep(10);
    }
    // Scenario 2
    //send collection numberBlock-times
    var input = new List<List<int>>(numberBlocks);
    for (int i = 0; i < numberBlocks; i++)
    {
        List<int> list = new List<int>(collectionSize);
        for (int j = 0; j < collectionSize; j++)
        {
            list.Add(j);
        }
        //broadCastBlock.Post(list);
        input.Add(list);
     }
     foreach (var inp in input)
     {
         broadCastBlock.Post(inp);
         Thread.Sleep(10);
     }
