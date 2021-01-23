    public void Execute(IJobExecutionContext context)
	{
			Console.WriteLine("Execute method for job {0} in group {1} called at {2}", context.JobDetail.Key.Name, context.JobDetail.Key.Group, DateTime.Now);
			Console.WriteLine("Trigger {0} in group {1} was fired", context.Trigger.Key.Name, context.Trigger.Key.Group);
	}
