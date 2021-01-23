    bool bCountry = false;
    bool bRegion = false;
    IDataEntryTarget target = null;
    
    if (!IsCityInfoAvailable())
    {
        // we have to make a new country, region and city
         city = new City(region, "Unnamed City", 0);
         target = city;
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
