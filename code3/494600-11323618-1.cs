    public IList<City> GetCities(int stateId)
    {
         return db.Cities.Where(c => c.StateId == stateId)
                         .ToList();
    }
    var cities = GetCities(x);
    foreach (var c in cities)
    {
        ddlCities.Items.Add(c.CityName);
    }
    var newCity = new City { CityName = "Home", StateId = x };
    cities.Add(newCity);
