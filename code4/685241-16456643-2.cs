    public bool OneOffSTIntersect()
    {
        var g =
            Microsoft.SqlServer.Types.SqlGeography.STGeomFromText(
                new System.Data.SqlTypes.SqlChars(
                    "POLYGON((-122.358 47.653, -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))"), 4326);
        // suffix "d" on literals below optional but explicit
        var h = Microsoft.SqlServer.Types.SqlGeography.Point(47.653d, -122.358d, 4326);
        // rough equivalent to SELECT
        System.Console.WriteLine(g.STIntersects(h));
        // Alternatively return from a C# method or property (get).
        return g.STIntersects(h);
    }
