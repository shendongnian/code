	Timer actualTimer = new Timer((obj) =>
	{
		Console.WriteLine("Timer!");
	}, null, 0, 1000);
	Timer killingTimer = new Timer((obj) =>
	{
		Console.WriteLine("Killing timer!");
		// Set the dueTime and timeout to infinite, to stop the timer.
		actualTimer.Change(Timeout.Infinite, Timeout.Infinite);
		// Optional:
		actualTimer = null;
	}, null, 5000, 5000);
	Console.ReadLine();
