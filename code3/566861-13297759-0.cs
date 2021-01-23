            //Create our service	
			PushService push = new PushService();
            
			//Wire up the events
			push.Events.OnDeviceSubscriptionExpired += new Common.ChannelEvents.DeviceSubscriptionExpired(Events_OnDeviceSubscriptionExpired);
			push.Events.OnDeviceSubscriptionIdChanged += new Common.ChannelEvents.DeviceSubscriptionIdChanged(Events_OnDeviceSubscriptionIdChanged);
			push.Events.OnChannelException += new Common.ChannelEvents.ChannelExceptionDelegate(Events_OnChannelException);
			push.Events.OnNotificationSendFailure += new Common.ChannelEvents.NotificationSendFailureDelegate(Events_OnNotificationSendFailure);
			push.Events.OnNotificationSent += new Common.ChannelEvents.NotificationSentDelegate(Events_OnNotificationSent);
			push.Events.OnChannelCreated += new Common.ChannelEvents.ChannelCreatedDelegate(Events_OnChannelCreated);
			push.Events.OnChannelDestroyed += new Common.ChannelEvents.ChannelDestroyedDelegate(Events_OnChannelDestroyed);
