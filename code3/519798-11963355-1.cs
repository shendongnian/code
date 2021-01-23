	private static IQueryable<Investment> PerformanceSearch(IQueryable<Investment> investments, string searchColumn, double minValue, double maxValue)
	{
		var entity = ExtendedEntities.Current;
		
		var wheres = new Dictionary<string, Expression<Func<Performance, bool>>>()
		{
			{ "Return1Month", p => p.Return1Month >= minValue && p.Return1Month <= minValue },
			{ "Return2Months", p => p.Return2Months >= minValue && p.Return2Months <= minValue },
			{ "Return3Months", p => p.Return3Months >= minValue && p.Return3Months <= minValue },
			{ "Risk1Month", p => p.Risk1Month >= minValue && p.Risk1Month <= minValue },
			{ "TrackingError1Month", p => p.TrackingError1Month >= minValue && p.TrackingError1Month <= minValue },
			/* etc */
		};
		
		var investments =
			from inv in entity.Investments 
			join perfromance in entity.Performances on inv.InvestmentID equals perfromance.InvestmentID
			select inv;
			
		return investments.Where(wheres[searchColumn]);
	}
