    bool bCountry = false;
    bool bRegion = false;
    IDataEntryTarget target = null;
    
    if (!IsCityInfoAvailable())
    {
        // we have to make a new country, region and city
         @class = new City(region, "Unnamed City", 0);
         target = city; // shouldn't this be target = @class or the above be city = new City()?
         bRegion = bCountry = true;
    }
    if (bRegion || !IsRegionInfoAvailable())
    {
        // we have to make a new country and region
        region = new Region(country, "Unnamed Region", Region.DefaultRegionSettings);
        if(null == target)
            target = region;
        bCountry = true;
    }
    if (bCountry || !IsCountryRegionAvailable())
    {
        // we have to make a new country
        country = new Country(Project, "Unnamed Country");
        if(null == target)
            target = country;
    }
