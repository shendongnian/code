        protected override void Update(Place place)
        {
            var dbPlace = MyDbContext.Instance().Places.Include(p => p.Address.State)
                .Single(p => p.ID == place.ID);
            // Update scalar properties of place
            MyDbContext.Instance().Entry(dbPlace)
                .CurrentValues.SetValues(place);
            // Update scalar properties of Address
            MyDbContext.Instance().Entry(dbPlace.Address)
                .CurrentValues.SetValues(place.Address);
            // Change relationship between Adress and State
            if (dbPlace.Address.State.ID != place.Address.State.ID)
            {
                MyDbContext.Instance().States.Attach(place.Address.State);
                dbPlace.Address.State = place.Address.State;
            }
            MyDbContext.Instance().SaveChanges();
        }
