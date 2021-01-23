	public int RollDice(int numDice, int numSides)
	{
        int total = 0;
		for (int i = 0; i < numDice; i++)
		{
			int roll;
			if(rnd.NextDouble() < 0.01)
				roll = rnd.Next(6, numSides);
			else
				roll = rnd.Next(1, 5);
				
			total += roll;
			result.AppendFormat("Congrats..!!! You got Dice {0:00}:\t{1}\n", i + 1, roll);
		}
        return total;
	}
