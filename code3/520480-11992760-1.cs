    protected override void OnClose(TimeSpan timeout)
    {
    	TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
    	while (true)
    	{
    		IChannel channel;
    		lock (base.ThisLock)
    		{
    			if (this.channelsList.Count == 0)
    			{
    				break;
    			}
    			channel = this.channelsList[0];
    		}
    		channel.Close(timeoutHelper.RemainingTime());
    	}
    }
