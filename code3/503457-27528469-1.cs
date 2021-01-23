	class DeltaPatternConverter : PatternLayoutConverter
	{
		private DateTime _last = DateTime.MinValue;
		protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
		{
			DateTime now = DateTime.Now;
			int ms = 0;
			if (_last != DateTime.MinValue)
			{
				ms = (int)Math.Round((now - _last).TotalMilliseconds, 0, MidpointRounding.ToEven);
			}
			writer.Write("+" + ms);
			_last = now;
		}
	}
