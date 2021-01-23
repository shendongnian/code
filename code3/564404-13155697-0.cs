    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        alien = Content.Load<Texture2D>("alien"); //only one texture needed
        ship = Content.Load<Texture2D>("ship");
        bullet = Content.Load<Texture2D>("bullet"); //only one texture needed
        //set initial positions as before
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                aliensPos[alienCount].X = 100 + (x * 40);
                aliensPos[alienCount].Y = 20 + (y * 40);
                alienCount++;
            }  
        }
    }
 
