    public static class GeoHelper
    {
        public const int SridGoogleMaps = 4326;
        public const int SridCustomMap = 3857;
    
        public static DbGeography PointFromLatLng(double lat, double lng)
        {
            return DbGeography.PointFromText(
                "POINT("
                + lng.ToString(CultureInfo.InvariantCulture) + " "
                + lat.ToString(CultureInfo.InvariantCulture) + ")",
                SridGoogleMaps);
        }
    }
    
    public County GetCurrentCounty(double latitude, double longitude)
    {
        var point = GeoHelper.PointFromLatLng(latitude, longitude);
    
        var county = db.Counties.FirstOrDefault(x =>
            x.Area.Intersects(point));
    
        return county;
    }
