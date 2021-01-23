	int GetMark(int studentID)
	{
		Console.Write("Enter mark for student " + studentID + ": ");
		int mark = Convert.ToInt32(Console.ReadLine());
		
		while (iMark < 0 || iMark > 100)
		{
			Console.Write("Not a percentage. Enter again: ");
			iMark = Convert.ToInt32(Console.ReadLine());
		}
		return mark;
	}
	
