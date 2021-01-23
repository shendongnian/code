    var neededProductStores = new List<Tuple<int, int>>
                                    {
                                        new Tuple<int, int>(1, 2),
                                        new Tuple<int, int>(1, 3),
                                        new Tuple<int, int>(2, 1),
                                        new Tuple<int, int>(3, 2)
                                    };
    
      IMongoQuery[] queries =(from t in neededProductStores
           select Query.And(Query.EQ("ItemId", t.Item1), Query.EQ("StoreId", t.Item2))).ToArray<IMongoQuery>();
      var queryToBringFourDocuments = Query.Or(queries);
