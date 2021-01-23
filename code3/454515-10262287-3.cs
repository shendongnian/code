    Func<Country> GetCountry = () => country ?? (country = new Country(Project, "Unnamed Country"));
    Func<Region> GetRegion = () => region ?? (region = new Region(GetCountry(), "Unnamed Region", Region.DefaultRegionSettings));
    Func<City> GetCity = () => city ?? (city = new City(GetRegion(), "Unnamed City", 0));
    IDataEntryTarget target = null;
    if (!IsCityInfoAvailable())
    {
        // we have to make a new country, region and city
         target = GetCity();
    }
    else if (!IsRegionInfoAvailable())
    {
        // we have to make a new country and region
        target = GetRegion();
    }
    else if (!IsCountryRegionAvailable())
    {
        // we have to make a new country
        target = GetCountry();
    }
