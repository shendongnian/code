    DateTime startTime = DateTime.UtcNow;
    while(true)
    {
        tryMethod();
        if(DateTime.UtcNow.Subtract(startTime).TotalMilliseconds > 5000)
            throw new TimeoutException();
    } 
