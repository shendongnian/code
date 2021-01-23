    using (Locations locs = new Locations { PersonId = personId,
    		 Latitude = latitude,
    		 Longitude = longitude,
    		 SentTimeUTC = sentTimeUTC,
    		 ReceivedTimeLocal = receivedTimeLocal,
    		 CivicAddress = civicAddress
    	}) {
    	using (var db = new SQLiteConnection(SQLitePath))
    	{
    	db.CreateTable<Locations>();
    
    	db.RunInTransaction(() =>
    		{
    			db.Insert(locs); // Still get, "Access to disposed closure" on this line.
    		});
    	}
    }
