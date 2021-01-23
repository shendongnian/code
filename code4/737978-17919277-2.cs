	// events are usually on the instance rather than static
	private static event EventHandler MyEvent;
	static void Main(string[] args)
	{
		MyEvent += (s, e) => Console.WriteLine("FooEvent");
		MyEvent += (s, e) => Console.WriteLine("BarEvent");
		MyEvent(null, EventArgs.Empty);
	}
