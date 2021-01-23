    var setOfStrings = new BsonValue[] { "a", "b", "c" };
    var query = Query.Or(
        Query.EQ("PropertyName", "test"),
        Query.In("List", setOfStrings)
    );
    var cursor = collection.FindAs<C>(query);
