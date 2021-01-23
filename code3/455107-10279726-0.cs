    public override void Update(GameTime gameTime)
    {
          // If enough time has passed attack
          if (lastTimeAttack + intervalBetweenAttack < gameTime.TotalGameTime)
          {
               Attack();
               lastTimeAttack = gameTime.TotalGameTime;
          }
    }
