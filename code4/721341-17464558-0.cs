	public static bool ListsEquals(List<int> listOne, List<int> listTwo)
	{
		if (listOne.Count != listTwo.Count)
			return false;
			
		if (!listOne.OrderBy(x => x).SequenceEqual(listTwo.OrderBy(x => x)))
			return false;
	}
	
