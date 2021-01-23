    var c = new HttpClient();
    c.Timeout = TimeSpan.FromMilliseconds(10);
    var cts = new CancellationTokenSource();
    try
    {
	    var x = await c.GetAsync("http://linqpad.net", cts.Token);	
    }
    catch(WebException ex)
    {
	    // handle web exception
    }
    catch(TaskCanceledException ex)
    {
	    if(ex.CancellationToken == cts.Token)
	    {
		    // a real cancellation, triggered by the caller
	    }
	    else
	    {
		    // a web request timeout (possibly other things!?)
	    }
    }
