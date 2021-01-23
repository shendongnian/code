    var doc = collection.FindOne(Query.EQ("_id", new ObjectId("4fb4fd04b748611ca8da0d48")));
    
    var standards = doc["categories"]
        .AsBsonArray[0]
        .AsBsonDocument["sub-categories"]
        .AsBsonArray;
    
    standards.Add(new BsonDocument());
    
    collection.Save(doc);
