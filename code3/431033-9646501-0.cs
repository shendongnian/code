    private const float MOVEMENT_SPEED = 10.0f; //pixels per second
    private float time;
    protected void PerformMovement(GameTime gameTime)
    {
        time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        character.X += MOVEMENT_SPEED * time;
    }
