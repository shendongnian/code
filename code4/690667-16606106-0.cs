    public static int PlusOrMinus()
    {
        int chance = MyRandom.Random.Next(0, 2);
		
		return chance == 0 ? -1 : 1;
	}
