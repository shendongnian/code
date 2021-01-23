    protected override void Update(GameTime gameTime)
    {
        MouseState mouse = Mouse.GetState();
        // Allows the game to exit
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            this.Exit();
        switch (CurrentGameState)
        {
            case GameState.MainMenu:
                if(btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                btnPlay.Update(mouse);
                if (btnQuit.isClicked == true)
                    this.Exit();
                    btnQuit.Update(mouse);
                  break;
            case GameState.Playing:
                  if (paused)
                  {
                      if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                      if (btnResume.isClicked)
                          paused = false;
                      if (btnMainMenu.isClicked) CurrentGameState = GameState.MainMenu;
                  }
                  else if (!paused)
                  {
                      if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                      {
                          paused = true;
                          btnResume.isClicked = false;
                      }
                      if (Keyboard.GetState().IsKeyDown(Keys.Space) && pastKey.IsKeyUp(Keys.Space))
                          Shoot();
          
                      pastKey = Keyboard.GetState();
                      spritePosition = spriteVelocity + spritePosition;
                      spriteRectangle = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, spriteTexture.Width, spriteTexture.Height);
                      spriteOrigin = new Vector2(spriteRectangle.Width / 2, spriteRectangle.Height / 2);
                      if (Keyboard.GetState().IsKeyDown(Keys.Right)) rotation += 0.025f;
                      if (Keyboard.GetState().IsKeyDown(Keys.Left)) rotation -= 0.025f;
                      if (Keyboard.GetState().IsKeyDown(Keys.Up))
                      {
                          spriteVelocity.X = (float)Math.Cos(rotation) * tangentialVelocity;
                          spriteVelocity.Y = (float)Math.Sin(rotation) * tangentialVelocity;
                      }
                      else if (Vector2.Zero != spriteVelocity)
                      {
                          float i = spriteVelocity.X;
                          float j = spriteVelocity.Y;
                          spriteVelocity.X = i -= friction * i;
                          spriteVelocity.Y = j -= friction * j;
                          base.Update(gameTime);
                      }
                      UpdateBullets();
                      break;
                  }
              }
        }
