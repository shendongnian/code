    IMongoQuery query = Query.LT("_id", entity.Id);
    IMongoSortBy sort = SortBy.Descending("_id");
    MongoCursor<Entity> cursor = collection.Find(query).SetSortOrder(sort).SetLimit(1);
    if (cursor.Size() > 0)
    {
        Entity previousEntity = cursor.First();
        Console.WriteLine(string.Format("Found {0} as the previous entry.", previousEntity.Id));
    }
