    protected override void Update (GameTime gameTime)
    {
        // ...
        if (!connected && !tryingToConnect)
        {
            ConnectSteam();
            
            // Remember to set to false once connection is established
            showConnectingDialog = true;
        } else
        {
            
        }
        // ...
    }
    protected override void Draw (GameTime gameTime)
    {
        // ...
        if (showConnectingDialog)
        {
            SpriteBatch.DrawString(SpriteFont, "Connecting to Steam servers...", Vector2.Zero, Color.White);
        } else
        {
            // ...
        }
    }
