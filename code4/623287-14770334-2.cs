	MouseState lastMouseState;
	protected override void Update(GameTime gameTime)
	{
		MouseState mouseState = Mouse.GetState();
		if(mouseState.LeftButton == ButtonState.Pressed
				&& lastMouseState.LeftButton == ButtonState.Released
				&& myShowUp == null)
		{
			Components.Add(myShowUp = new ShowUp(this));
		}
		lastMouseState = mouseState;
		base.Update(gameTime);
	}
