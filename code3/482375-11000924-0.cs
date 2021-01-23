    Document doc = new Document();
    while (reader.Read())
    {
        // read from db
        double lat = reader.GetDouble(1);
        double lon = reader.GetDouble(2);
        string country = reader.GetString(3);
        string county = reader.GetString(4);
        double TIV = reader.GetDouble(5);
        double cnpshare = reader.GetDouble(6);
        double locshare = reader.GetDouble(7);
        var currentData = new data(lat, lon, country, county, TIV, cnpshare, locshare));
        // write to file
        Point point = new Point();
        point.Coordinate = new Vector(currentData.lat, currentData.lon);
        Placemark placemark = new Placemark();
        placemark.Geometry = point;
        placemark.Name = Convert.ToString(currentData.tiv);
        doc.AddFeature(placemark);
    }
