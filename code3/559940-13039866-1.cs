	public void GetInput()
	{
		int inputValue = 0;
		bool isValidInput = false;
		List<int> validEntries = new List<int> { 1,2,3, 42, 55, 69};
		while (!isValidInput)
			isValidInput = int.TryParse(Console.ReadLine(), out inputValue) && validEntries.Contains(inputValue);
		switch (inputValue)
		{
			case 1:
				{
					// something
					break;
				}
			case 2:
				{
					// something else
					break;
				}
			default:
				{
					//yet something else
					break;
				}
		}
	}
