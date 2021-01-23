	public static int Compare(int i1, int i2)
	{
		int result = 0;
		while(i1 != 0 && i2 != 0)
		{
			var d1 = i1 % 10;
			var d2 = i2 % 10;
			i1 /= 10;
			i2 /= 10;
			if(d1 == d2)
			{
				++result;
			}
			else
			{
				result = 0;
			}
		}
		if(i1 != 0 || i2 != 0)
		{
			throw new ArgumentException("Integers must be of same length.");
		}
		return result;
	}
