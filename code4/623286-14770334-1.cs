	class ShowUp : DrawableGameComponent
	{
		public ShowUp(Game game) : base(game) { }
		Texture2D texture;
		SpriteBatch sb;
		protected override void LoadContent()
		{
			sb = new SpriteBatch(GraphicsDevice);
			texture = this.Game.Content.Load<Texture2D>("test");
			base.LoadContent();
		}
		public override void Draw(GameTime gameTime)
		{
			sb.Begin();
			sb.Draw(texture, new Vector2(100), Color.White);
			sb.End();
			base.Draw(gameTime);
		}
	}
