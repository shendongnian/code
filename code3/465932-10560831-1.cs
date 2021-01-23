    protected override void LoadContent()
    {
        device = graphics.GraphicsDevice;
        spriteBatch = new SpriteBatch(GraphicsDevice);
    
        SetUpCamera();
    
        effect = Content.Load<Effect>("effects");
    
        SetUpVerticies();
    }
