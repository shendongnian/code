	List<Holding> holdings = new List<Holding>();
	holdings.Add(new Holding(){ date=Convert.ToDateTime("01-06-2010"), HoldingId = "1" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("02-06-2010"), HoldingId = "1" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("04-06-2010"), HoldingId = "1" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("02-06-2010"), HoldingId = "2" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("03-06-2010"), HoldingId = "2" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("05-06-2010"), HoldingId = "2" });
	holdings.Add(new Holding(){ date=Convert.ToDateTime("03-06-2010"), HoldingId = "3" });
	
	List<DateTime> dateRange = new List<DateTime>();
	dateRange.Add(Convert.ToDateTime("01-06-2010"));
	dateRange.Add(Convert.ToDateTime("02-06-2010"));
	dateRange.Add(Convert.ToDateTime("03-06-2010"));
	dateRange.Add(Convert.ToDateTime("04-06-2010"));
	dateRange.Add(Convert.ToDateTime("05-06-2010"));
	
	Dictionary<string, List<DateTime>> missingHoldings = new Dictionary<string, List<DateTime>>();
	foreach(var holdGrp in  holdings.GroupBy (h => h.HoldingId))
	{
		var missingDates = dateRange.Except(holdGrp.Select(h => h.date)).ToList();
		missingHoldings.Add(holdGrp.Key, missingDates);
	}
