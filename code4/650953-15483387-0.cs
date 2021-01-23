        void Main()
		{
		    const int rowCount = 10;
		    Console.Write("**");
		    for (var rowNumber = 0; rowNumber < rowCount - 1; rowNumber++)
		    {
		        Console.Write("\n ");
		        for (var spaceCount = 0; spaceCount < rowNumber; spaceCount++)
		        {
			        Console.Write(" ");
		        }
		        Console.Write("**");
		    }
		}
