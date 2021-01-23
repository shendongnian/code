	abstract class BaseState
	{
		public GameState UpdateState(GameTime gameTime)
		{
			GameState g = GameState.MainMenu;
			try
			{
				g = Update(gameTime); // Update returns a new state
			}
			catch (Exception e)
			{
			}
			return g;
		}
		protected abstract GameState Update(GameTime gameTime);
		protected abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
	}
	class InGame : BaseState
	{
		public InGame()
		{
		}
		protected override GameState Update(GameTime gameTime)
		{
			return GameState.Quit;
		}
		protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			// Draw game
		}
	}
	class InMenu : BaseState
	{
		public InMenu()
		{
		}
		protected override GameState Update(GameTime gameTime)
		{
			return GameState.Pause;
		}
		protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			// Draw menu
		}
	}
	void Foo()
	{
		List<BaseState> states = new List<BaseState>();
		states.Add(new InGame());
		states.Add(new InMenu());
		
		// Calls InGame.Update(...)
		states[0].UpdateState(...);
		
		// Calls InMenu.Update(...)
		states[1].UpdateState(...);
	}
