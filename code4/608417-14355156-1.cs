    public static void Main()
    {
        var address = "Stavanger, Norway";
        var locationService = new GoogleLocationService();
        var point = locationService.GetLatLongFromAddress(address);
        var latitude = point.Latitude;
        var longitude = point.Longitude;
        // Save lat/long values to DB...
    }
