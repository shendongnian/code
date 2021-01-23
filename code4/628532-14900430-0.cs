    class Connection
    {
        private TcpClient socket;
        private NetworkStream socketStream;
        private int bytesRead;
        private Task<int> readTask;
    	private Stack<byte[]> buffersToProcess;
    	private readonly object lockObject = new object();
    
    	public Connection(TcpClient socket)
    	{
    		this.socket = socket;
    		socketStream = socket.GetStream();
    		var buffer = new byte[4096];
    
    		readTask = Task.Factory.FromAsync<byte[], int, int, int>(
    			this.socketStream.BeginRead
    			, this.socketStream.EndRead
    			, buffer
    			, 0
    			, buffer.Length
    			, null
    			);
    		readTask.ContinueWith(
    			(task) =>
    				{
    					this.bytesRead = (int) task.Result;
    					var actualBytes = new byte[bytesRead];
    					Array.Copy(buffer, 0, actualBytes, 0, bytesRead);
    					lock (lockObject)
    					{
    						buffersToProcess.Push(actualBytes);
    					}
    					// TODO: do something with buffersToProcess
    				}
    			, TaskContinuationOptions.OnlyOnRanToCompletion
    			);
    	}
    }
