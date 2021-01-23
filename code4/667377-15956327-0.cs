    if (PlayerInput.IsKeyDown(Keys.P) && oldInput.IsKeyUp(Keys.P))
    {
      switch (this.gameState)
      {
        case GameState.Paused:
          this.gameState = GameState.InGame;
          break;
        case GameState.InGame:
          this.gameState = GameState.Paused;
          break;
      }
    }
