    var collection = db.GetCollection<dynamic>(collectionName);
    await collection.InsertManyAsync(new List<dynamic>()
    {
        new
        {
            PointType = "Building",
            Name = "My Place",
            Location = GeoJson.Point(GeoJson.Position(lng, lat))
        }
    });
