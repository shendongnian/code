	string[] newStrings = newString.Split(' ');
	if (newStrings.Length < 3)
	{
		//error
	}
	else if (newStrings[0][0] != '[')
	{
		//error
	}
	else
	{
		int newValue = 0;
		int currentValue = 0; //TODO; get your current value based on the newStrings[0]
		int changeValue;
		int.TryParse(newStrings[2], out changeValue);
		switch (newStrings[1])
		{
			case "+":
				{
					newValue = currentValue + changeValue;
					break;
				}
			case "-":
				{
					newValue = currentValue - changeValue;
					break;
				}
			default:
				{
					//error
					break;
				}
		}
		//do something with new value
	}
