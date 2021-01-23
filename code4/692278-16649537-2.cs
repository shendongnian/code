    Dictionary<String, Result> accessMap;
    List<Result> MyCache;
    accessMap["Object 1"] = obj1;
    MyCache.add(obj1);
    
    accessMap[Object 1].Increase();
    //sort MyCache    
    foreach(Result result in MyCache) {
      Console.Write(result.Name + " - hits " + result.Hits);
    }
