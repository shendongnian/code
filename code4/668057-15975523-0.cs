    public static DbGeography CreatePoint(double latitude, double longitude)
    {
        var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                 "POINT({0} {1})", longitude, latitude);
        // 4326 is most common coordinate system used by GPS/Maps
        return DbGeography.PointFromText(text, 4326);
    }
