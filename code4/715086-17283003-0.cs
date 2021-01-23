	bool SolveSudoku()
	{
		if (FindUnassignedLocation())
		{
			for (int num = 1; num <= 9; num++)
			{
				if (NoConflicts(emptyRow, emptyCol, num))
				{
					Grid[emptyRow, emptyCol].Text = num.ToString();
					return true;
				}
			}
		}
		return false;
	}
