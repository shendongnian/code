    LinkedList<MyType> TheQueue = new LinkedList<MyType>();
    object listLock = new object();
    void Enqueue(MyType item)
    {
        lock (listLock)
        {
            TheQueue.AddFirst(item);
            while (TheQueue.Count > MaxQueueSize)
            {
                // Queue overflow. Reduce to max size.
                TheQueue.RemoveLast();
            }
        }
    }
