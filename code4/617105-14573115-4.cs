    public void Update(Location location, DateTime locationLastUpdated)
    {
        using (var context = new EfContext())
        {
            location.LastUpdated = locationLastUpdated;
            context.Locations.Attach(location);
            context.Entry(location).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
