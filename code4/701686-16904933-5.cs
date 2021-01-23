    public FooListViewModel()
    {
        DateTime today = DateTime.Today;
        DateTime later = DateTime.Today.AddDays(5);
        var ds = DomainServices();
        fooItems = ds.Foo.GetFilteredFoos(/* some params */);
    }
