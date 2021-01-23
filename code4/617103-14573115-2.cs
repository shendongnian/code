    public void Update(Location location)
    {
        using (var context = new EfContext())
        {
            location.LastUpdated = DateTime.Now;
            context.Locations.Attach(location);
            context.Entry(location).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
