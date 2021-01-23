    private float NextRandomFloat(double max, double min)
    {
        var number = r.NextDouble() * (max - min) + min;
        
        return (float) number;
    }
    
    private Vector2 GetRandomSpeed(float dx, float dy)
    {
        var speedX = NextRandomFloat(2.0, 0.5) * dx;
        var speedY = NextRandomFloat(2.0, 0.5) * dy;
        var vector = new Vector2(speedX, speedY);
        
        return vector;
    }
    
    private Vector2 cloudSpeed;
    private Vector2 cloudPosition;
    
    protected override void Update(GameTime gameTime)
    {
            if (cloudPosition.X <= 500)
            {
                // Tinker with the dx to manage acceleration
                // Consider using MathHelper.Clamp for a maximum speed.
                cloudSpeed += GetRandomSpeed(1.0f, 0);
            }
            else
            {
                cloudSpeed.X = 0;
            }
            
            cloudPosition += cloudSpeed;
    
            base.Update(gameTime);
    }
    
    private void DrawCloud()
    {
        spriteBatch.Draw(cloudTexture, cloudPosition, Color.White);
    }
