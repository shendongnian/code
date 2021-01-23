    var rnd = new Random();
    var hugeList = new List<List<int>>();
    for (int i = 0; i < 10000; i++)
    {
        var innerList = new List<int>();
        for (int ii = 0; ii < 5; ii++)
        {
            innerList.Add(rnd.Next(1,100000));
        }
        hugeList.Add(innerList);
    }
