    var dispatches = new Dictionary<LocationType, Action<int, int>>();
    dispatches.Add(LocationType.Country, SomeMethod<DataCountry>);
    dispatches.Add(LocationType.State, SomeMethod<DataState>);
    //... and etc.
    
    dispatches[LocationType.Country](1, 2); // the same as SomeMethod<DataCountry>(1,2)
