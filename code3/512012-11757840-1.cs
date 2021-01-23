    var tables = new List<int>[36];
    for(var i=0;i<36;i++)
    {
        tables[i] = new List<int>();
    }
    
    var stack = new Queue<int>(Enumerable.Range(1,300));
    while(stack.Count>0)
    {
        var next = stack.Dequeue();
        var table = tables[random.Next(0,36)];
        table.Add(next);
    }
