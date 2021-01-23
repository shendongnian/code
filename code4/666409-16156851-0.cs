    public void Connect(Action<Exception> callback, string hostname, int port, bool ssl, RemoteCertificateValidationCallback validateCertificate)
    {
    	if (State != ConnectionState.Disconnected)
    		throw new InvalidOperationException(AlreadyConnectedString);
    
    	Host = hostname;
    	Port = port;
    	Ssl = ssl;
    	State = ConnectionState.Connecting;
    
    	var callingThread = TaskScheduler.FromCurrentSynchronizationContext();
    
    	Action connectAction = () =>
    	{
    		// Connect asynchronously in order to specify a timeout
    		TcpClient connection = new TcpClient();
    		connection.SendTimeout = SendTimeout;
    		connection.ReceiveTimeout = ReadTimeout;
    
    		IAsyncResult ar = connection.BeginConnect(hostname, port, null, null);
    		WaitHandle waitHandle = ar.AsyncWaitHandle;
    
    		try
    		{
    			if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(ConnectTimeout), false))
    				throw new TimeoutException();
    
    			connection.EndConnect(ar);
    		}
    		finally
    		{
    			waitHandle.Close();
    		}
    
    		Stream stream = connection.GetStream();
    
    		if (ssl)
    		{
    			SslStream sslStream;
    
    			if (validateCertificate != null)
    				sslStream = new SslStream(stream, false, validateCertificate);
    			else
    				sslStream = new SslStream(stream, false);
    
    			sslStream.AuthenticateAsClient(hostname);
    
    			stream = sslStream;
    		}
    
    		lock (_locker) // Perform thread unsafe operations here
    		{
    			_connection = connection;
    			_stream = stream;
    		}
    
    		OnConnected(GetResponse());
    	};
    
    	Action<Task> completeAction = (Task task) =>
    	{
    		Exception ex = (task.Exception != null) ? task.Exception.InnerException : task.Exception;
    
    		if (task.Exception != null)
    		{
    			Cleanup();
    		}
    		else
    		{
    			State = ConnectionState.Authorization;
    		}
    
    		if (callback != null)
    			callback(ex);
    	};
    
    	Task.Factory.StartNew(connectAction, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
    				.ContinueWith(completeAction, callingThread);
    }
