    Action<int> handler = i => Console.WriteLine(i + 1);
    Process(handler, 4);
    public void Process(object myDelegate, object data)
    {
        ((Delegate)myDelegate).DynamicInvoke(data);
    }
