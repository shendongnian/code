        protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
        base.Update(gameTime);
        TouchCollection touchPoints = TouchPanel.GetState();
        if (touchPoints.Count > 0)
        {
            TouchLocation t = touchPoints[0];
            if (t.State == TouchLocationState.Pressed)
            {
                shouldDraw = true;
            }
        }
    }
