    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
    
        SetUpCamera();
    
        effect = Content.Load<Effect>("effects");
    
        SetUpVerticies();
    
        device = graphics.GraphicsDevice;
    }
