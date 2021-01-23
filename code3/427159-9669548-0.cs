    protected override void Update(GameTime gameTime)
    {
    // Allows the game to exit
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
    this.Exit(); //this
    // TODO: Add your update logic here
    base.Update(gameTime);
    }
