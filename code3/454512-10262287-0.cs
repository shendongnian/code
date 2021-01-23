    bool bCountry = false;
    bool bRegion = false;
    
    if (!IsCityInfoAvailable())
    {
        // we have to make a new country, region and city
         @class = new City(region, "Unnamed City", 0);
         target = city; // this looks like an error here, but just copied your code
         bRegion = bCountry = true;
    }
    if (bRegion || !IsRegionInfoAvailable())
    {
        // we have to make a new country and region
        region = new Region(country, "Unnamed Region", Region.DefaultRegionSettings);
        target = region;
        bCountry = true;
    }
    if (bCountry || !IsCountryRegionAvailable())
    {
        // we have to make a new country
        country = new Country(Project, "Unnamed Country");
        target = country;
    }
