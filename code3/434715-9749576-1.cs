        LinkedList<MyNodeData> l = new LinkedList<MyNodeData>();
        var d = new MyNodeData();
        d.MyInt = 10;
        d.MyString = "Node message";
        d.Children.AddLast(new MyNodeData(11, "Child 1 message"));
        d.Children.AddLast(new MyNodeData(12, "Child 2 message"));
        l.AddLast(d);
        Console.WriteLine(l.First.Value.MyString);
        Console.WriteLine(l.First.Value.Children.Last.Value.MyInt);
