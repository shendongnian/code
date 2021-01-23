    private MouseState oldMouseState, currentMouseState;
    protected override void Update(GameTime gameTime)
    {
         oldMouseState = currentMouseState;
         currentMouseState = Mouse.GetState();
         //TODO: Update your code here
    }
