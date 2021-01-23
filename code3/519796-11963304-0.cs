	private static IQueryable<Investment> PerformanceSearch(IQueryable<Investment> investments, string searchColumn, double minValue, double maxValue)
	{
	  var entity = ExtendedEntities.Current;
	  investments = from inv in entity.Investments 
					join perfromance in entity.Performances on inv.InvestmentID equals perfromance.InvestmentID
					where
					(
						(searchColumn = "Return1Month" && perfromance.Return1Month >= minValue && perfromance.Return1Month <= maxValue) ||
						(searchColumn = "Return2Months" && perfromance.Return2Months >= minValue && perfromance.Return2Months <= maxValue) ||
						(searchColumn = "Return3Months" && perfromance.Return3Months >= minValue && perfromance.Return3Months <= maxValue) ||
						(searchColumn = "Risk1Month" && perfromance.Risk1Month >= minValue && perfromance.Risk1Month <= maxValue)
						// continue like this for as many columns, unless you want to use reflection
					)
	  return investments;
	}
