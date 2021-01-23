    public class SafeQueue<T> : Queue<T>
    {
        public T SafeDequeue()
        {
            lock (this)
            {
                return (Count > 0) ? Dequeue() : null;
            }
        }
        public void SafeEnqueue(T entry)
        {
            lock (this)
            {
                Enqueue(entry);
            }
        }
    }
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
        while ((Order order = ordersToRegister.SafeDequeue()) != null)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        while ((var entry = aggrUpdates.SafeDequeue()) != null)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        while ((var entry = commonUpdates.SafeDequeue()) != null)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        while ((var entry = infoUpdates.SafeDequeue()) != null)
        {
            marketDataUpdated = true;
            // Stage1, Process
        }
        while ((var entry = tradeUpdates.SafeDequeue()) != null)
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
    private readonly SafeQueue<Order> ordersToRegister = new SafeQueue<Order>();
    private readonly SafeQueue<AggrEntry> aggrUpdates = new SafeQueue<AggrEntry>();
    private readonly SafeQueue<CommonEntry> commonUpdates = new SafeQueue<CommonEntry>();
    private readonly SafeQueue<InfoEntry> infoUpdates = new SafeQueue<InfoEntry>();
    private readonly SafeQueue<TradeEntry> tradeUpdates = new SafeQueue<TradeEntry>();
        public void RegistorOrder(object sender, Gate.RegisterOrderArgs e)
        {
            ordersToRegister.SafeEnqueue(e.order);
        }
        public void TradeUpdated(object sender, Gate.TradeArgs e)
        {
            foreach (var entry in e.entries)
            {
                tradeUpdates.SafeEnqueue(entry);
            }
        }
        public void InfoUpdated(object sender, Gate.InfoArgs e)
        {
            foreach (var entry in e.entries)
            {
                infoUpdates.SafeEnqueue(entry);
            }
        }
        public void CommonUpdated(object sender, Gate.CommonArgs e)
        {
            foreach (var entry in e.entries)
            {
                commonUpdates.SafeEnqueue(entry);
            }
        }
        public void AggrUpdated(object sender, Gate.AggrArgs e)
        {
            foreach (var entry in e.entries)
            {
                aggrUpdates.SafeEnqueue(entry);
            }
        }
