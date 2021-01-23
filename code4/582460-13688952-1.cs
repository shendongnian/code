    foreach (var dirFile in dirFiles.AsParallel())
    {
        var order = new Order(dirFile, this, convention);
        _synchronizationContext.Post(AddItem, order);
    }
...
    void AddItem(object item)
    {
        // this is executed on the consumer thread
        // All access to OrderCollection on this thread so no need for synchnonization
        Order order = (Order) item;
        if (!OrdersCollection.ContainsOrder(order))
        {
            OrdersCollection.Add(order);
        }
    }
