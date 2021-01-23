    using System;
    namespace Test
    {
        public static void Main()
	{
		Console.WriteLine("Press CTRL+C to exit, otherwise press any key.");
		ConsoleKeyInfo cki;
		do
		{
			cki = Console.ReadKey(true);
			if (!Char.IsNumber(cki.KeyChar))
			{
				Console.WriteLine("Non-numeric input");
			}
			else
			{
				Int32 number;
				if (Int32.TryParse(cki.KeyChar.ToString(), out number))
				{
					Console.WriteLine("Number received: {0}; <9? {1}", number, number < 9);
				}
				else
				{
					Console.WriteLine("Unable to parse input");
				}
			}
		}
		while (cki.KeyChar != 27);
	}
    }
