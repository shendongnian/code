    var collection = MongoDatabase.GetCollection<ClockRecord>("Clocks");
    var update = Update.Set("FilesList.$.FileStatus", "TEST");      <-----$ added here
    var result = collection.Update(
            Query.And(
              Query.EQ("_id", clockDocumentID),
              Query.ElemMatch("FilesList",Query.EQ("FileName","AAA-TEST123-002.mpg"))
            ),  
            update, UpdateFlags.Upsert
    );
