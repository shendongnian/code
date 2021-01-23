    bool isInside(DbGeometry polygon, double longitude, double latitude) //or DbGeography in your case
    {
        DbGeometry point = DbGeometry.FromText(string.Format("POINT({0} {1})",longitude, latitude), 4326);
        return polygon.Contains(point);    
    }
