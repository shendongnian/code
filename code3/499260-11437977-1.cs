    class Program
	{
		static void someMethod(ActionData data)
		{
			Console.WriteLine("SUP");
		}
		static void Main(string[] args)
		{
			Action[] actions = new Action[] {
				new Action(Program.someMethod, new ActionData(), true)
			};
			foreach(Action a in actions) 
				a.run();
		}
	}
