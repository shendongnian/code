    	var sortedSystemTestResultsList = systemTestResultsList.OrderBy(s =>
		{
			DateTime dt;
			if (!DateTime.TryParse(s.testPointCompletedDate, out dt)) return DateTime.MaxValue;
			return dt;
		}).ThenBy(s =>
		{
			Int32 tpID;
			if (!Int32.TryParse(s.testRunResultID, out tpID)) return Int32.MaxValue;
			return tpID;
		});
