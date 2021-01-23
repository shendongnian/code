    protected override void Draw(GameTime gameTime) 
    { 
        if (animation != null)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); 
            spriteBatch.Begin(); 
            animation.Draw(spriteBatch);    
            spriteBatch.End(); 
        }
        base.Draw(gameTime); 
    } 
