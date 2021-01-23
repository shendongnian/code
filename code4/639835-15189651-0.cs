    var andList = new List<IMongoQuery>();
    
    foreach (var attribute in item.Attributes)
    {
        andList.Add(Query.EQ("Attributes.AttributeName", attribute.AttributeName));
        andList.Add(Query.EQ("Attributes.AttributeValue", attribute.AttributeValue));
    }
    
    andList.Add(Query.EQ("TemplateId", item.TemplateId));
    andList.Add(Query.NE("UsernameOwner", item.UsernameOwner));
    var query = new QueryBuilder<Item>();
    query.And(andList);
    // do something with query ...
