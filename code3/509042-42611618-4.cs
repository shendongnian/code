	void Main()
	{
		Greet(1,"foo", "bar");
		Greet(1, 2, "bar");
		Greet(1,"foo", new object());
		Greet(1,2,3);
		Greet(1,2,3,4);
	}
	public void Greet(int i, params object[] foo)
	{
		Console.WriteLine("Number then param array of objects!");
	}
	public void Greet(int i, int x, params object[] foo)
	{
		Console.WriteLine("Number, ...nuther number, and finally object[]!");
	}
	public void Greet(int i, string x, params object[] foo)
	{
		Console.WriteLine("number, then string, then object[]!");
	}
