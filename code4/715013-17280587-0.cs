    using (var subscription = redisClient.CreateSubscription())
    {
        subscription.OnUnSubscribe = channel => 
           Log.Debug("OnUnSubscribe: " + channel);
        subscription.OnMessage = (channel, msg) =>
        {
            if (msg == "STOP")
            {
                Log.Debug("UnSubscribe From All Channels...");
                subscription.UnSubscribeFromAllChannels(); //Un block thread.
                return;
            }
            handleMessage(msg);
        }   
        ...
        //Unsubscribing will unblock this subscription:
        subscription.SubscribeToChannels(QueueNames.TopicIn); //blocks thread
    }
