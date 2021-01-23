	string _val = "";
	Console.Write("Enter your value: ");
	ConsoleKeyInfo key;
	do
	{
		key = Console.ReadKey(true);
		if (key.Key != ConsoleKey.Backspace)
		{
			double val = 0;
			bool _x = double.TryParse(key.KeyChar.ToString(), out val);
			if (_x)
			{
				_val += key.KeyChar;
				Console.Write(key.KeyChar);
			}
		}
		else
		{
			if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
			{
				_val = _val.Substring(0, (_val.Length - 1));
				Console.Write("\b \b");
			}
		}
	}
	// Stops Receving Keys Once Enter is Pressed
	while (key.Key != ConsoleKey.Enter);
	Console.WriteLine();
	Console.WriteLine("The Value You entered is : " + _val);
	Console.ReadKey();
