    class Game
    {
	void Update(GameTime gameTime)
	{
		// ...
		
		ball.Update(gameTime);
	
		if(ball.LeftSide < LEFT_BOUNDS)
		{
			score.blueScore++;		
			ball.MoveToCenter();
		}
		if(Ball.RightSide > RIGHT_BOUNDS)
		{
			score.greenScore++;
			ball.MoveToCenter();
		}
		
		// ...
	}
	
	void Draw(GameTime gameTime)
	{
		// ...
		
		_spriteBatch.Draw(ballTexture, ball.DrawDestination, Color.White);
		
		// ...
	}
    }
