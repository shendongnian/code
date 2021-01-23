    public async Task<MapLocation> ReverseGeocodeAsync(GeoCoordinate location)
    {
        var query = new ReverseGeocodeQuery { GeoCoordinate = location };
    
        if (!query.IsBusy)
        {
            var mapLocations = await query.ExecuteAsync();
            return mapLocations.FirstOrDefault();
        }
        return null;
    }
