    using(Entities context = new Entities())
    {
        Location NewLocation = new Location
        {
          State = context.States.SingleOrDefault(s => s.Name == AddedState),
          Country = context.Countries.SingleOrDefault(c => c.Name == AddedCountry),
          City = context.Cities.SingleOrDefault(c => c.Name == AddedCity)
        };
        context.AddToLocation(NewLocation);
        context.SaveChanges();
    }
