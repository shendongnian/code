    ConcurrentQueue<ICommand> queue = ConcurrentQueue<ICommand>();
    queue.Enqueue(new A());
    queue.Enqueue(new B());
    Object item;
    while (queue.TryDequeue(out item))
    {
        item.execute();
    }
