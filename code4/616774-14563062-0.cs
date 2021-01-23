    public void AddOrder(string order)
    {
        lock (Orders) //access across threads
        {
            if (null == Orders)
                Orders = new List<string>();
            Orders.Add(order);
        }
    }
