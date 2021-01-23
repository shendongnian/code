    return (from geoLocation in _entities.ViewGeographyLocation
     where geoLocation.CountryCode == countryCode
     orderby geoLocation.SortOrder, geoLocation.CityName
     select new ContinentModel
     {
      ContinentCode = geoLocation.ContinentCode,
      ContinentName = geoLocation.ContinentName,
      CountryCode = geoLocation.CountryCode,
      CountryName = geoLocation.CountryName,
      CityId = geoLocation.CityId,
      CityName = geoLocation.CityName,
      CityCode = geoLocation.CityName,
      TotalCount = myVal 
     });
