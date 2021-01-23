    public void ShowBestHours()
    {
    	using (NorthwindDataContext db = new NorthwindDataContext())
    	{
    		var query = db.Orders.GroupBy(x =>  x.OrderDate.Value.Hour).OrderByDescending(x => x.Count()).Select(x => new Stime { HourTime = x.Key, Count = x.Count() });	
    			
    		foreach (var item in query)
    		{
    			Console.WriteLine("Hour : {0},Order(s) Number : {1}", item.HourTime, item.Count);
    		}
    	}
    }
