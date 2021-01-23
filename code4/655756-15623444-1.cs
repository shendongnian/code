    public async Task ThrottleRequest(string webservice)
    {
        if (cache.TryGet(webservice)
        {
            var timeToWait = GetTimeToWaitFromSomewhere(); 
            await Task.Delay(timeToWait);
        }
    }
