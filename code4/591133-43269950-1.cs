    //1st.- You would have a colection of entities:
    var myEntities = new List<MyEntity>();
    // [...] With thousands or millions of items
    
    // 2nd.- You would create the BulkInsert:
    myEntityTypeBulk = new BulkInsert<MyEntity>(_connectionString, "MyEntitiesTableName", myEntities, new[] { "ObjectState", "SkippedEntityProperty1", "SkippedEntityProperty2" });
    
    // 3rd.- You would execute it:
    myEntityTypeBulk.Insert();
