    var milliseconds = DateTimeToTimeSpan(timePicker.Value).TotalMilliseconds;
		TimeSpan DateTimeToTimeSpan(DateTime? ts)
		{
			if (!ts.HasValue) return TimeSpan.Zero;
			else return new TimeSpan(0, ts.Value.Hour, ts.Value.Minute, ts.Value.Second, ts.Value.Millisecond);
		}
