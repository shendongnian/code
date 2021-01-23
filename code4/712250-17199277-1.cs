    public static IMongoQuery WithinCircle(string name, double centerX, double centerY, double radius, bool spherical)
    {
        if (name == null)
        {
            throw new ArgumentNullException("name");
        }
        var shape = spherical ? "$centerSphere" : "$center";
        var condition = new BsonDocument("$within", new BsonDocument(shape, new BsonArray { new BsonArray { centerX, centerY }, radius }));
        return new QueryDocument(name, condition);
    }
