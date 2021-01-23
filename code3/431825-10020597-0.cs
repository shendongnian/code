    public void InsertFoo(Foo f)
    {
        var db = new Database("connection");           
        var petaPocoFooObj = new {f.Id}
        db.Insert("FooTable", "FooId", petaPocoFooObj);
    }
