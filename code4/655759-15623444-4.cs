    public async Task ThrottleRequest(string webservice)
    {
        if (cache.TryGet(webservice))
        {
            var timeToWait = GetTimeToWaitFromSomewhere(); 
            await Wait(timeToWait);
        }
    }
    
    public async Task Wait(TimeSpan timeToWait)
    {
         await Task.Delay(timeToWait);
    }
