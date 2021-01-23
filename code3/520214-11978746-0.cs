    using(Entities context = new Entities())
    {
        Location NewLocation = new Location
        {
          State = context.States.SingleOrDefault(s => s.ID == AddedState.ID),
          Country = context.Countries.SingleOrDefault(c => c.ID == AddedCountry.ID),
          City = context.Cities.SingleOrDefault(c => c.ID == AddedCity.ID)
        };
        context.AddToLocation(NewLocation);
        context.SaveChanges();
    }
