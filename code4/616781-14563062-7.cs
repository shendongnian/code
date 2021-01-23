    private object ordersLock = new object();
    public void AddOrder(string order)
    {
        lock (ordersLock) //access across threads
        {
            Orders.Add(order);
        }
    }
