    var lists = new List<List<Object1>>();
    for (int i = 0; i < numberBlocks; i++)
    {
        List<Object1> list = new List<Object1>();
        for (int j = 0; j < collectionSize; j++)
        {
            list.Add(new Object1(j));
        }
        lists.Add(list);                
        broadCastBlock.Post(list);
    }
