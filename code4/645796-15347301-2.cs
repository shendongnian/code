    var list = new LinkedList(arry.Cast<int>()); // flattens array
    var node = list.First;
    while(node != list.Last)
    {
        Console.WriteLine("Value {0}", node.Value);
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
