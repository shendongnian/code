    for (int i = 100, h = 100; i < 999; i++, h++)
		{
			num = i * h;
			snum = num.ToString();
			first = snum.ToCharArray()[0];
			second = snum.ToCharArray()[4];
			if (snum.ToCharArray().Length > 5)
			{
				second = snum.ToCharArray()[5]; //Line of interest
			}
			if (first == second)
			{
				final = snum;
			}
		}
