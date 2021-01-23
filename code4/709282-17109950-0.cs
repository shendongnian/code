    // get adjustments for user
    IEnumerable<Severity> existingSeverities = 
        from s in db.AdjusterPricingGrossLossSeverities
        where s.type == type
        && s.adjusterID == adj.id
        select new Severity
        {
            id = s.severity,
            adjustment = roundtest(s.adjustment.GetValueOrDefault()),
            isT_E = (bool)s.isTimeAndExpense
        };
    // test method...
	public string roundtest(double num)
	{
		return num.ToString("#.##");
	}
