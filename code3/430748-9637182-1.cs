    void Main()
    {
    	var today = DateTime.Now;  // or UtcNow if you need to
    	var todayMidnight = today.Date; 
    	var yesterdayMidnight = todayMidnight.AddDays(-1);
    	var yesterday6pm = yesterdayMidnight.AddHours(18);
    
    	var trips = new List<Trip>
    	{
    		new Trip{ bookTime = todayMidnight },
    		new Trip{ bookTime = yesterdayMidnight }
    	};
    	
    	var a = trips.Where(t=>t.bookTime > yesterday6pm).ToList();
    }
    
    // Define other methods and classes here
    class Trip{
    	public DateTime bookTime{get;set;}
    }
