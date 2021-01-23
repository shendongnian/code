	// The Player class
	public class Player
	{
		// Constructor
		public Player(int strength, int statPoints)
		{
			this.Strength = strength;
			this.StatPoints = statPoints;
		}
		// Method to gain strength if enough StatPoints
		public bool GainStrength()
		{        
			bool playerHasEnoughStatPoints = true;
			if (this.StatPoints < 1)
			{
				playerHasEnoughStatPoints = false;
			}
			else if (this.Strength < 8)
			{
				this.Strength++;
				this.StatPoints--;
			}
			return playerHasEnoughStatPoints;
		}
		// Property for StatPoints
		public int StatPoints { get; set; }
		// Property for Strength
		public int Strength { get; set; }
    }
	
