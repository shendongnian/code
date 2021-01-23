    var pipeline = new BsonArray
            {
                new BsonDocument
                    {
                        {
                            "$match", 
                            new BsonDocument
                                {
                                    {"CustomerAppId", "f5357224-b1a8-4f1a-8ea2-a06a00ca597a"},
                                    {"ActionName", "install"}
                                }
                        }
                },
                new BsonDocument
                    {
                        { "$group", 
                            new BsonDocument
                                {
                                    { "_id", new BsonDocument
                                                 {
                                                     {
                                                         "CustomerAppId","$CustomerAppId"
                                                     },
                                                     {
                                                         "ActionDate","$ActionDate"
                                                     }
                                                 } 
                                                 
                                    },
                                    {
                                        "Count", new BsonDocument
                                                     {
                                                         {
                                                             "$sum", 1
                                                         }
                                                     }
                                    }
                                } 
                      }
                    }
            };
