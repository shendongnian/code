    async public void UseGeoLocation()
        {
            Geolocator _GeoLocator = new Geolocator();
            Geoposition _GeoPosition = await _GeoLocator.GetGeopositionAsync();
            Clipboard.Clear();
            Clipboard.SetText("latitude," + _GeoPosition.Coordinate.Latitude.ToString() + "," +
                                 "longitude," + _GeoPosition.Coordinate.Longitude.ToString() + "," +
                                 "heading," + _GeoPosition.Coordinate.Heading.ToString() + "," +
                                 "speed," + _GeoPosition.Coordinate.Speed.ToString());
            Application.Exit();
        }
