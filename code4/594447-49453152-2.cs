    public static DbGeography MakePolygonValid(this DbGeography geom)
    {
        var wellKnownText = geom.AsText();
        //First, get the area defined by the well-known text using left-hand rule
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
        return DbSpatialServices.Default.GeographyFromProviderValue(sqlGeography);
    }
