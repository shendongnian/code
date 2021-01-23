    IEnumerable<Entity> data = db.GetMyLazilyEvaluatedListOfEntities();
    //this will fail
    data.Where(e => e.Foo.Contains("bar"));
    data = new List<Entity>();
    //this will work
    data.Where(e => e.Foo.Contains("bar"));
