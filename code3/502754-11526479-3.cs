    void Process(SomeType foo)
    {
        Stack<SomeType> bar=new Stack<SomeType>();
        bar.Push(foo);
        while(bar.Any())
        {
            var item=bar.Pop();
            DoWork(item);//work on item
            foreach(var child in item.Children)
            {
                bar.Push(child);
            }
        }
    }
