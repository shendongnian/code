    string _val = "";
	Console.Write("Enter your value: ");
	ConsoleKeyInfo key;
	do
	{
		key = Console.ReadKey(true);
		if (char.IsNumber(key.KeyChar) || key.KeyChar == '.')
		{
			_val += key.KeyChar;
			Console.Write(key.KeyChar);
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
