    int readInput()
	{
		int sec;
		while(true)
		{
			try
			{
				sec = Convert.ToInt16(Console.ReadLine());
				return sec;
			}
			catch(Exception e) 
                        { 
                                Console.WriteLine("Enter an integer!");
                        }
		}
		return 0;
	}
