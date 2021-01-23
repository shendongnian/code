    class Ship
    {
      public void Update(GameTime gameTime)
      {
        ...
        position.Y += spd * (gameTime.ElapsedGameTime.Milliseconds / 16);
        ...
      }
      ..
    }
