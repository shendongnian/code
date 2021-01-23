	static void Main()
	{
		string s;
		try
		{
			Fjuk(out s);
			Console.WriteLine(s ?? "");//fine
		}
		catch (Exception)
		{
			Console.WriteLine(s ?? "");//compiler error
		}
		Console.WriteLine(s ?? "");//compiler error
	}
