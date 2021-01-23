    public bool Cancelled { get; set; }
    
    IConnection _connection = null;
    IModel _channel = null;
    Subscription _subscription = null;
    
    public void Run(string brokerUri, string queueName, Action<byte[]> handler)
    {
    	ConnectionFactory factory = new ConnectionFactory() 
    	{
    		Uri = brokerUri,
    		RequestedHeartbeat = 30,
    	};
    	
    	while (!Cancelled)
    	{               
    		try
    		{
    			if(_subscription == null)
    			{
    				try
    				{
    					_connection = factory.CreateConnection();
    				}
    				catch(BrokerUnreachableException)
    				{
    					//You probably want to log the error and cancel after N tries, 
    					//otherwise start the loop over to try to connect again after a second or so.
    					continue;
    				}
    				
    				_channel = _connection.CreateModel();
    				_channel.QueueDeclare(queueName, true, false, false, null);
    				_subscription = new Subscription(_channel, queueName, false);
    			}
    			
    			BasicDeliverEventArgs args;
    			bool gotMessage = _subscription.Next(250, out args);
    			if (gotMessage)
    			{
    				if(args == null)
    				{
    					//This means the connection is closed.
    					DisposeAllConnectionObjects();
    					continue;
    				}
    				
    				handler(args.Body);
    				_subscription.Ack(args);
    			}
    		}
    		catch(OperationInterruptedException ex)
    		{
    			DisposeAllConnectionObjects();
    		}
    	}
        DisposeAllConnectionObjects();
    }
    	
    private void DisposeAllConnectionObjects()
    {
    	if(_subscription != null)
    	{
            //IDisposable is implemented explicitly for some reason.
    		((IDisposable)_subscription).Dispose();
    		_subscription = null;
    	}
    
    	if(_channel != null)
    	{
    		_channel.Dispose();
    		_channel = null;
    	}
    
    	if(_connection != null)
    	{
    		try
    		{
    			_connection.Dispose();
    		}
    		catch(EndOfStreamException) 
    		{
    		}
    		_connection = null;
    	}
    }
