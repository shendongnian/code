    // create the $elemMatch with Type and Value
    // as we're just trying to make an expression here, 
    // we'll use $elemMatch as the property name 
    var qType1 = Query.EQ("$elemMatch", 
        BsonValue.Create(Query.And(Query.EQ("Type", 1),
                         Query.EQ("Value", "a"))));
    // again
    var qType2 = Query.EQ("$elemMatch", 
        BsonValue.Create(Query.And(Query.EQ("Type", 2), 
                         Query.EQ("Value", "b"))));
    // then, put it all together, with $all connection the two queries 
    // for the Properties field
    var query = Query.All("Properties", 
        new List<BsonValue> { 
            BsonValue.Create(qType1), 
            BsonValue.Create(qType2)
        });
