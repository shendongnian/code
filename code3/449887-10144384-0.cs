    DateTime startTime = DateTime.Now;
    while(true)
    {
        tryMethod();
        if(DateTime.Now.Subtract(startTime).TotalMilliseconds > 5000)
            throw new TimeoutException();
    } 
