	public async Task Listen(string prefix, int maxConcurrentRequests, CancellationToken token)
	{
		HttpListener listener = new HttpListener();
		listener.Prefixes.Add(prefix);
		listener.Start();
		var requests = new HashSet<Task>();
		for(int i=0; i < maxConcurrentRequests; i++)
			requests.Add(listener.GetContextAsync());
		while (!token.IsCancellationRequested)
		{
			Task t = await Task.WhenAny(requests);
			requests.Remove(t);
			if (t is Task<HttpListenerContext>)
			{
				var context = (t as Task<HttpListenerContext>).Result;
				requests.Add(ProcessRequestAsync(context));
				requests.Add(listener.GetContextAsync());
			}
		}
	}
	public async Task ProcessRequestAsync(HttpListenerContext context)
	{
		...do stuff...
	}
