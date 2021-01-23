    public async Task<MapLocation> ReverseGeocodeAsync(GeoCoordinate location)
    {
        var query = new ReverseGeocodeQuery { GeoCoordinate = location };
        if (!query.IsBusy)
        {
            var mapLocations = await query.ExecuteAsync();
            if (mapLocations != null && mapLocations.Any())
                return mapLocations.First();
        }
        return null;
    }
