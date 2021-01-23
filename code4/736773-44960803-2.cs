			var zonedDateTimeString = context.Reader.ReadString();
			var parseResult = ZonedDateTimePattern.CreateWithInvariantCulture("G", DateTimeZoneProviders.Tzdb)n.Parse(zonedDateTimeString);
			if (!parseResult.Success)
			{
				throw parseResult.Exception;
			}
			return parseResult.Value;
