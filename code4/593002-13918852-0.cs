	public class Player
	{
		int lives = 5;
		public bool Kill()
		{
			this.lives--;
			return this.lives <= 0;
		}
		public void run()
		{
			Player player = new Player();
			
			// do stuff
			// Check whether the player needs to die
			if ("player fails".Contains("fail"))
			{
				if (player.Kill())
				{
					// restart level.
				}
				else
				{
					// Game over.
				}
			}
		}
	}
