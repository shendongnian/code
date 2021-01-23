		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = 480;
			graphics.PreferredBackBufferHeight = 800;
			graphics.IsFullScreen = true;
			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks(333333);
			// Extend battery life under lock.
			InactiveSleepTime = TimeSpan.FromSeconds(1);
		}
