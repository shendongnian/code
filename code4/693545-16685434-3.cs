	public int RollDice(int numDice, int numSides)
	{
        int total = 0;
		for (int i = 0; i < numDice; i++)
		{
			int roll;
			if(rnd.NextDouble() < 0.01)
				roll = rnd.Next(6, Math.Min(12, numSides) + 1);
			else
			{
				roll = rnd.Next(1, numSides - (Math.Min(12, numSides) - 6 + 1) + 1);
				if(roll >= 6)
					roll += (Math.Min(12, numSides) - 6 + 1);
			}
				
			total += roll;
			result.AppendFormat("Congrats..!!! You got Dice {0:00}:\t{1}\n", i + 1, roll);
		}
        return total;
	}
