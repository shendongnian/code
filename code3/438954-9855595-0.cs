    public IQueryable<Speaker> GetSpeakers()
    {
        var speakers = db.Speakers.OrderBy(x => x.DisplayName);
        var newVidsSpeakers = db.Videos.Where(x => x.DatePosted > DateTime.Now.AddDays(-7)).Select(x => x.Speaker).Distinct();
        foreach (var speaker in newVidsSpeakers)
        {
            speaker.HasNew = true;
        }
        return speakers;
    }
