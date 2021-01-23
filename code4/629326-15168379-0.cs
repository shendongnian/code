    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            Iterate();
        }
    }, TaskCreationOptions.LongRunning);
    private void Iterate()
    {
        bool marketDataUpdated = false;
        foreach (Order order in ordersToRegister)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        foreach (var entry in aggrUpdates)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        foreach (var entry in commonUpdates)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        foreach (var entry in infoUpdates)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        foreach (var entry in tradeUpdates)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        if (marketDataUpdated)
        {
            // Stage2 !
            // make a lot of work. expensive operation. recalculate strategies, place orders etc.
        }
    }
    private readonly ConcurrentQueue<Order> ordersToRegister = new ConcurrentQueue<Order>();
    private readonly ConcurrentQueue<AggrEntry> aggrUpdates = new ConcurrentQueue<AggrEntry>();
    private readonly ConcurrentQueue<CommonEntry> commonUpdates = new ConcurrentQueue<CommonEntry>();
    private readonly ConcurrentQueue<InfoEntry> infoUpdates = new ConcurrentQueue<InfoEntry>();
    private readonly ConcurrentQueue<TradeEntry> tradeUpdates = new ConcurrentQueue<TradeEntry>();
        public void RegistorOrder(object sender, Gate.RegisterOrderArgs e)
        {
            ordersToRegister.Enqueue(e.order);
        }
        public void TradeUpdated(object sender, Gate.TradeArgs e)
        {
            foreach (var entry in e.entries)
            {
                tradeUpdates.Enqueue(entry);
            }
        }
        public void InfoUpdated(object sender, Gate.InfoArgs e)
        {
            foreach (var entry in e.entries)
            {
                infoUpdates.Enqueue(entry);
            }
        }
        public void CommonUpdated(object sender, Gate.CommonArgs e)
        {
            foreach (var entry in e.entries)
            {
                commonUpdates.Enqueue(entry);
            }
        }
        public void AggrUpdated(object sender, Gate.AggrArgs e)
        {
            foreach (var entry in e.entries)
            {
                aggrUpdates.Enqueue(entry);
            }
        }
