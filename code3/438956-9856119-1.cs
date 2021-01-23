    public IEnumerable<Speaker> GetSpeakers()
    {
        var speakers = db.Speakers;
    	var lastWeek = DateTime.Now.Date.AddDays(-7);
        var recentVideos = db.Videos.Where(x => (x.DatePosted.Date >= lastWeek)).ToArray();
    	
        foreach (var speaker in speakers)
    	    speaker.HasNew = recentVideos.Any(x => (x.Speaker == speaker));
    		
    	return speakers.OrderBy(x => x.DisplayName);
    }
