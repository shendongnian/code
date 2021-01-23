    protected void AddZombie(GameTime gameTime)
    {
        float elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
        timer -= (int)elapsed;
        if (timer <= 0)
        {
            timer = 10;   //Reset Timer
            // Rest of stuff goes here
        }
    }
    protected void Update(GameTime gameTime)
    {
        AddZombie(gameTime);
    }
