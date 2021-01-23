	public static bool ListsEquals(List<int> listOne, List<int> listTwo)
	{
		if (listOne.Count != listTwo.Count)
			return false;
			
		if (!listOne.Except(listTwo).Any())
			return false;
		
		return true;
	}
