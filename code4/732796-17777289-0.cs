	Console.Write("How wide do we want the multiplication table? ");
	int width = Convert.ToInt32(Console.ReadLine());
	Console.Write("How high do we want the multiplication table? ");
	int height = Convert.ToInt32(Console.ReadLine());
	Console.Write("    ");
	for (int i = 0; i < width; i++) 
		Console.Write("_____");
	Console.WriteLine("__");
	Console.Write("    x|");
	for (int x = 1; x <= width; x++)
		Console.Write("{0, 5}", x);
	Console.WriteLine();
	for (int row = 1; row <= height; row++)
	{
		Console.Write("{0, 5}|", row);
		for (int column = 1; column <= height; ++column)
		{
			Console.Write("{0, 5}", row * column);
		}
		Console.WriteLine();
	}
	Console.ReadLine();
