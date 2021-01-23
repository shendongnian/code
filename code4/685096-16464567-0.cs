    SpriteBatch mBatch;
    Texture2D mTheQuantumBros2;
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        mBatch = new SpriteBatch(this.graphics.GraphicsDevice);
        //Create the Content Manager object to load images
        ContentManager aLoader = new ContentManager(this.Services);
        //ADD THIS
        aLoader.RootDirectory = "Content";
        //Use the Content Manager to load the Cat Creature image into the Texture2D object
        mTheQuantumBros2 = aLoader.Load<Texture2D>("TheQuantumBros2") as Texture2D;
        // TODO: use this.Content to load your game content here
    }
