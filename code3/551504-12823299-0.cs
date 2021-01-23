    public static IQueryable<Device> WhereCloseToGeocode(
        this IQueryable<Device> source,
        Geocode geocode,
        double distanceMetres)
    {
        return source.Where(device => Math.Pow(
            Math.Pow(device.Address.Geocode.Easting - geocode.Easting, 2) +
            Math.Pow(device.Address.Geocode.Northing - geocode.Northing, 2),
            0.5) <= distanceMetres);  
    }
    public static IQueryable<Device> OtherCondition(
        this IQueryable<Device> source, ...)
    {
       ...
    }
    ...
    devices = devices
        .WhereCloseToGeocode(geocode1, 3)
        .WhereCloseToGeocode(geocode2, 7)
        .OtherCondition(...);
