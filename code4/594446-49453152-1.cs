    public bool IsInside(DbGeography polygon, double longitude, double latitude)
    {
        DbGeography point = DbGeography.FromText(string.Format("POINT({1} {0})", latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.')), DbGeography.DefaultCoordinateSystemId);
        var wellKnownText = polygon.AsText();
        var sqlGeography =
            SqlGeography.STGeomFromText(new SqlChars(wellKnownText), DbGeography.DefaultCoordinateSystemId)
                .MakeValid();
        //Now get the inversion of the above area
        var invertedSqlGeography = sqlGeography.ReorientObject();
        //Whichever of these is smaller is the enclosed polygon, so we use that one.
        if (sqlGeography.STArea() > invertedSqlGeography.STArea())
        {
            sqlGeography = invertedSqlGeography;
        }
        polygon = DbSpatialServices.Default.GeographyFromProviderValue(sqlGeography);
        return point.Intersects(polygon);
    }
