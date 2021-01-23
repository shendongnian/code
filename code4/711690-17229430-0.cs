    static PullSubscription s_Subscription;
    static void Main()
    {
        ExchangeService service = CreateService();
        CreateSubsciption(service);
        //DoSomething;
        GetEvents();
        //DoSomething;
        StoreWatermark(s_Subscription.Watermark);
    }
    static void CreateSubscription(ExchangeService Service)
    {
        string watermarkt = LoadWatermark(); 
        s_Subscription = service.SubscribeToPullNotificationsOnAllFolders(
            5, watermark,
            EventType.Moved, EventType.Deleted, EventType.Copied, EventType.Modified);
    }
    static void GetEvents()
    {
        GetEventsResults events = subscription.GetEvents();
        foreach (ItemEvent itemEvent in events)
        {
            switch (itemEvent.EventType)
            {
                case EventType.Moved:
                    MessageBox.Show("Item Moved :" + itemEvent.ItemId.UniqueId);
                    break;
                case EventType.Deleted:
                    MessageBox.Show("Item deleted: " + itemEvent.ItemId.UniqueId);
                    break;
                case EventType.Copied:
                    MessageBox.Show("Item Copied :" + itemEvent.ItemId.UniqueId);
                    break;
                case EventType.Modified:
                    MessageBox.Show("Item Modified :" + itemEvent.ItemId.UniqueId);
                    break;
            }
        }
    }
