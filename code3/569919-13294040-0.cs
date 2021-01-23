    Track filter = records.Aggregate(
        new Track() { City = _city, Country = _country, Name = _name },
        (f, t) => new Track()
        {
            City = String.IsNullOrEmpty(t.City) ? null : f.City, 
            Country = String.IsNullOrEmpty(t.Country) ? null : f.Country,
            Name = String.IsNullOrEmpty(t.Name) ? null : f.Name
        },
        f => f);
