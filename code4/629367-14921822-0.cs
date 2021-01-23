    public void ShowBestHour()
    {
    	using (NorthwindDataContext db = new NorthwindDataContext())
    	{            
    		var bestHour = db.Order_Details.GroupBy(x => x.Order.OrderDate.Value.Hour).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
    	}
    }
