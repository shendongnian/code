    var forecasts = (List<ForecastData>)cache.Get(_RAW_FORECAST_DATA_KEY, null);
    
    var forecastGroups = forcasts
        .Where(f => f.Year = DateTime.Now.Year)
        .GroupBy(f => f.Customer)
        .Where(grp => grp.Count() > 1)
        .Select(grp => new { Key = grp.Key, SalesGroups = grp.GroupBy(f => f.SalesId) });
    foreach(var custGroup in forecastGroups)
    {
        if(custGroup.SalesGroups.Count() > 1)
        {
            foreach(var salesGroup in custGroup.SalesGroups)
            {
                toReturn.Add(new MultipleCustomer(custGroup.Key)
                {
                    Salesperson = salesGroup.Key,
                    Forecast = salesGroup.Sum(f => f.Amount)
                });
            }
        }
    }
    
    return toReturn;
