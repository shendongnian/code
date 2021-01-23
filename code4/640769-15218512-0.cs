    public Task<List<Foo>> GetFeed(Uri uri)
    {
    	var tcs = new TaskCompletionSource<List<Foo>>(); //used to transform a synchronous method into an asynchronous.
    	WebClient webClient = new WebClient();
    	webClient.DownloadStringAsync(uri);
    	webClient.DownloadStringCompleted += async(sender,e)=>
    	{
    		tcs.SetResult(e.Result); //Method ended, can now return. 
    	};
    	return tcs.Task;
    }
