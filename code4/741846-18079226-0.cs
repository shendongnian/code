    using(var Session = Sessionfactory = OpenSession())
    {
        var root = Session.Query<RootObject>().FetchMany(x => x.Collection).ToFutureValue();
        Session.Query<RootObjectCollection>().Fetch(x => x.Ref).FetchMany(x => x.Collection).ToFuture();
    
        // Do something with root.Value
    }
