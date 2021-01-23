    //at top of class
    private TimeSpan previousTime;
    private TimeSpan targetTime = new TimeSpan(0, 0, 5); //5 seconds
    private bool isFirstUpdate = true;
    
    //later down in your update
    public void Update(GameTime gameTime)
    {
        if(isFirstUpdate)
        {
            previousTime = new TimeSpan(gameTime.TotalElapsedTime.Ticks);
            isFirstUpdate = false;
        }
        if(gameTime.TotalElapsedTime - previousTime >= targetTime)
        {
            //do some event, and don't forget to re-set previous time
            previousTime = new TimeSpan(gameTime.TotalElapsedTime.Ticks);
        }
    }
