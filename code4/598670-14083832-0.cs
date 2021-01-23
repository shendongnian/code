    AutoResetEvent _stopEvent = new AutoResetEvent(false);
    object _lock = new object();
    
    public void StartListening()
    {
    	_listener.BeginAcceptTcpClient(ConnectionHandler, null);
    	_stopEvent.WaitOne();//this part is different in my original code, I don't wait here
    }
    
    public void StopListening()
    {
    	lock(_lock)
    	{
    		listener.Stop();
    		listener = null;				
    	}
    	
    	_stopEvent.Set();//this part is different in my original code
    }
    
    void ConnectionHandler(IAsyncResult asyncResult)
    {
    	lock(_lock)
    	{
    		if(_listener == null)
    			return;
    	
    		var tcpClient = _listener.EndAcceptTcpClient(asyncResult);
    		var task = new MyCustomTask(tcpClient);
    		ThreadPool.QueueUserWorkItem(task.Execute);
    
    		_listener.BeginAcceptTcpClient(ConnectionHandler,null);				
    	}
    }
