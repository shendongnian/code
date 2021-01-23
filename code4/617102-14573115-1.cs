    The proper place to set the LastUpdated property is actually the database where it should have default value of getDate() (sql function), because record is updated when it will be updated in the database, not in app
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
