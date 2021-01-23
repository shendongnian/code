	C c = new C();
	c.E += (args) => PrintOut(args);
	c.SenderE += (sender, args) => Console.WriteLine("Sender Type: " + sender.GetType().Name + " -> Args: " + args.Args);
	c.Go();
    private void PrintOut(string text)
    {
    	Console.WriteLine(text);
    }
