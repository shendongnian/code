	public DateTime CalculateNextRunTime()
	{
		var now = DateTime.Now;
		for (var i = 0; i<=7; i++)
		{
			var potentialRunTime = now.AddDays(i);
			if (!DateInDayOfWeek(potentialRunTime))
				continue;
			potentialRunTime = potentialRunTime.Date + TimeToRun;
			if (potentialRunTime < DateTime.Now)
				continue;
			return potentialRunTime;
		}
		return DateTime.MinValue;
	}
