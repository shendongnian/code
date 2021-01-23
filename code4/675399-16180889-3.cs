    protected override void Draw(GameTime gameTime)
    {
    GraphicsDevice.Clear(Color.Black) //Add a background and clear screen each frame
    
        if (timeElapsed > spawnAsteroid) //If time is more than or equal to the time needed to spawn
        {
            DrawAdsteroid();
            timeElapsed = 0f;
        }
    }
