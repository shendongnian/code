    class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Console.CursorLeft = 0;
			Console.CursorTop = 1;
			Console.Write("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
			char first = ReadCharacterAt(10, 1);
			char second = ReadCharacterAt(20, 1);
			Console.ReadLine();
		}
	}
