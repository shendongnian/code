	public static void SmallestMultiple()
	{
		const ushort ARRAY_SIZE = 21;
		ushort[] array = new ushort[ARRAY_SIZE];
		ushort check = 0;
		for (uint value = 19; value < uint.MaxValue; value += 19)
		{
			for (ushort j = 1; j < ARRAY_SIZE; j++)
			{
				array[j] = j;
				if (value % array[j] == 0)
				{
					check++;
				}
			}
			if (check == 20)
			{
				Console.WriteLine("The value is {0}", value);
				return;
			}
			else
			{
				check = 0;
			}
		}
	}
