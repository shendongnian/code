	void CompletionCallback<T>(IAsyncResult iar)
		where T : EventArgs
	{
		var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
		var invokedMethod = (EventHandler<T>)ar.AsyncDelegate;
		invokedMethod.EndInvoke(iar);
	}
