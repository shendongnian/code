	static void Main(string[] args)
	{
		ConsoleHelp ch1 = new ConsoleHelp();
		Plus pl = new Plus();
		Minus mn = new Minus();
		Divide dv = new Divide();
		Multiply mlt = new Multiply();
		Sinus sin = new Sinus();
		Tangent tan = new Tangent();
		Square sq = new Square();
		Degree dg = new Degree();
		Percent pr = new Percent();
		
		var commands = new Dictionary<string, Action>(StringComparer.InvariantCultureIgnoreCase)
			{
				{ "?", ch1.Helper },
				{ "plus", p1.Sum },
				{ "minus", mn.MinusValue },
				{ "divide", dv.DivideValue },
				{ "multiply", mlt.Multvalue },
				{ "sinus", sin.Sinusvalue }, 
				{ "tangent", tan.Tangentvalue }, 
				{ "square", sq.Squarevalue }, 
				{ "degree", dg.Degvalue }, 
				{ "percent", pr.Pervalue}, 
				{ "c", () => Environment.Exit(0) }
			};
		while (true)
		{
			Console.Write("command> ");
			string com = Console.ReadLine();
			if (!String.IsNullOrEmpty(com))
			{
				Action action;
				if(commands.TryGetValue(com))
					action();
				else
					Console.WriteLine("The command is not supported. Enter one of the valid commands.");
			}
		}
	}
			
        
