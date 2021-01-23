    public void AIMovement(GameTime gameTime, Ninjas playerNinja)
    {
        sourceRect = new Rectangle(30 * currentFrame, 0, 30, 37);
    
        if (position_b.X > playerNinja.Position.X)
        {
            AnimateLeftAI(gameTime);
            if (position_b.X < 20)
            {
                position_b.X += spriteSpeed;
            }
        }
    
        if (position_b.X < playerNinja.Position.X)
        {
            AnimateRightAI(gameTime);
            if (position_b.X < 1100)
            {
                position_b.X += spriteSpeed;
            }
        }
    
    }
