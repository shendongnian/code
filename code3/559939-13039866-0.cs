	public void GetInput()
	{
		int inputValue = 0;
		bool isValidInput = false;
		while (!isValidInput)
			isValidInput = int.TryParse(Console.ReadLine(), out inputValue);
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
