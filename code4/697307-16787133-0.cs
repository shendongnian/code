    //Declares a timespan of 2 seconds
    TimeSpan timeSpan = TimeSpan.FromMilliseconds(2000);
    
    
    public override void Update(GameTime gameTime)
    {
        // Decrements the timespan
        timeSpan -= gameTime.ElapsedGameTime;
        // If the timespan is equal or smaller time "0"
        if (timeSpan <= TimeSpan.Zero )
        {
            // Remove the object from list
            scoreList.RemoveAt(1);
            // Re initializes the timespan for the next time
            timeSpan = TimeSpan.FromMilliseconds(2000);
        }
    
        base.Update(gameTime)
    }
