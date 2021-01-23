	public void Execute(IJobExecutionContext context)
	{
		if (context.IsMissedFire(1000))
			Console.WriteLine("Missfire");
		else
			Console.WriteLine("Fire");
	}
