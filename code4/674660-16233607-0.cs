   	public void SubscribePullNotifications(FolderId folderId)
	{
		Subscription = Service.SubscribeToPullNotifications(new FolderId[] { folderId }, 1440, null, EventType.NewMail, EventType.Created, EventType.Deleted);
	}
    public void GetPullNotifications()
    {
		IEnumerable<ItemEvent> itemEvents = Subscription.GetEvents().ItemEvents;
		foreach (ItemEvent itemEvent in itemEvents)
		{
			switch (itemEvent.EventType)
			{
				case EventType.NewMail:
					MessageBox.Show("New Mail");
					break;
			}
		}
    }
    // ...
    SubscribePullNotifications(WellKnownFolderName.Inbox);
    Timer myTimer = new Timer();
    myTimer.Elapsed += new ElapsedEventHandler(GetPullNotifications);
    myTimer.Interval = 10000;
    myTimer.Start();
