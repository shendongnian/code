	class Event 
	{
		string Description;
		List<Activity> Activities;
	}
	class Activity
	{
		string Description;
	}
	List<Event> ParseEventLines(IEnumerable<string> allLines)
	{
		var result = new List<Event>();
		
		Event currentEvent = null;
		
		foreach (var line in allLines)
		{
			if (line.StartsWith("*"))
			{
				currentEvent = new Event { Description = line };
				result.Add(currentEvent);
			}
			else if (line.StartsWith("#"))
			{
				currentEvent.Activities.Add(new Activity { Description = line });
			}
		}
		
		return result;
	}
