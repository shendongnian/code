    public IList<City> GetCities(int stateId)
    {
         return db.Cities.Where(c => c.StateId == stateId)
                         .ToList();
    }
