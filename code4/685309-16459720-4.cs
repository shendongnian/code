	static public bool Partition(IList<int> numbers, out IList<int> group0, out IList<int> group1)
	{
		if (numbers == null)
			throw new ArgumentNullException("numbers");
	
		BitArray groupPerNumber = new BitArray(numbers.Count);
		while (true)
		{
			groupPerNumber.Increase(); // Increate the numberic value of the BitArray.
			if (groupPerNumber.IsEmpty()) // If all bits are zero, all iterations have been done.
				break;
			// Create the new groups.
			group0 = new List<int>();
			group1 = new List<int>();
			// Fill the groups. The bit in the groups-array determains in which group a number will be place.
			for (int index = 0; index < numbers.Count; index++)
			{
				int number = numbers[index];
				if (!groupPerNumber[index])
					group0.Add(number);
				else
					group1.Add(number);
			}
			// If both sums are equal, exit.
			if (group0.Sum() == group1.Sum())
				return true;
		}
		group0 = group1 = null;
		return false;
	}
