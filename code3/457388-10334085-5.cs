	public void DivideSubArray(int[] array)
	{
		List<int> odds = new List<int>(array.Length);
		List<int> evens = new List<int>(array.Length);
		foreach (var i in array)
		{
			if ((i % 2) == 0)
				evens.Add(i);
			else
				odds.Add(i);
		}
		odds.CopyTo(array);
		evens.CopyTo(array, odds.Count);
	}
