    public TimeSpan GetTotalDuration()
		{
			var duration = GetDuration();
			if(SubTasks != null && SubTasks.Count > 0)
			{
				foreach (var t in SubTasks)
				{
					duration += t.GetTotalDuration();
				}	
			}
            return duration;
		}
