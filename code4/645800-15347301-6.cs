    var list = new LinkedList(arry.Cast<int>.Select((item, i) => new 
    { 
        Item = item, 
        Index1 = i % arry.GetLength(1), 
        Index2 = i / arry.GetLength(0) 
    }));
    var node = list.First;
    while(node.Next != null)
    {
        Console.WriteLine("Value @ {1}, {2}: {0}", node.Value.Item, node.Value.Index1, node.Value.Index2);
        // on some condition move to previous node
        if (...)
        {
            node = node.Previous;
        }
        else
        {
            node = node.Next;
        }
    }
