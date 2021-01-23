	static void Main(string[] args)
	{
		IGameEngine engine = new GameEngine();
		Scripts.AttackPlayer(engine);
		while(true)
		{
			engine.NextFrame();
			Thread.Sleep(100);
		}
	}
