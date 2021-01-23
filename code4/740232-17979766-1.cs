    const int NUM_IMAGES = 2; // or whatever
    Texture2D[] images = new Texture2D[NUM_IMAGES];
    double elapsedTime = 0;
    int currentFrame = 0;
    double frameInterval = .5; // the time, in seconds, between frames
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // load all of your images. here, I'm assuming that they are numbered.
        for (int i = 0; i < NUM_IMAGES; i++)
            images[i] = Content.Load<Texture2D>("image" + i);
    }
    protected override void Update(GameTime gameTime)
    {
        // increment elapsed time by the frametime
        elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedTime >= frameInterval)
        {
            // reset the elapsed time, and then update the frame counter.
            elapsedTime %= frameInterval;
            currentFrame++;
            if (currentFrame >= NUM_IMAGES)
                currentFrame %= NUM_IMAGES;
        }
    }
    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        // images[currentFrame] to draw the correct frame.
        spriteBatch.Draw(images[currentFrame], new Rectangle(244, 536, 32, 32), Color.White);
        spriteBatch.End();
    }
