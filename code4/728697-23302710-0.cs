    foreach (var notification in args.Events.OfType<ItemEvent>())
    {
	  if (notification.EventType == EventType.Moved)
	  {
		ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "usersemail@domain.com");
		var item = Item.Bind(service, notification.ItemId);
	  }
    }
}`
