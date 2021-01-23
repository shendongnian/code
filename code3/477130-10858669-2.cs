	string[,] table3x3 = new string[3, 3];  
	string myString = "11A23A4A5A87A5";
	string[] splitA = myString.Split(new char[] { 'A' });
	
	int index = 0;
	bool first = true;
	foreach (string part in splitA)
	{
		int row = index / 3;
		int col = index % 3;
		
		if (!first)
		{
			table3x3[row, col] = part[0].ToString();
		}
		
		index += part.Length;
		first = false;
	}
