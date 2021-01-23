    // extra variables
    bool justReleased = false;
    double vy, vx;
    ...
    protected override void Update(GameTime gameTime)
    {
        // ...
            if (holding)
            {
                released = true;
                holding = false;
                lastTimeHeld = timeHeld;
                justReleased = true; // add this here
            }
        // ...
    
        if (released && timeHeld > 0)
        {
            float alpha = MathHelper.ToRadians(45f);
            // not local variables anymore. Also I flipped the sign - my intention is that initial vertical velocity is "upwards"
            if(justReleased)
            {
                vy = -1 * timeHeld * Math.Sin(alpha); 
                vx = timeHeld * Math.Cos(alpha);
                justReleased = false;
            }
    
            ShadowPosition.Y += (int)vy; // Note: I flipped this operator
            ShadowPosition.X += (int)vx;
            timeHeld -= velocityHeld;
            // increase the downward velocity
            vy += 2; // or some constant. I can't test this. :\
        }
        else
        {
            released = false;
        }
    }
