    public override IEnumerable<BaseClass> MakeList()
    {
        List<DerivedClass> d = new List<DerivedClass>();
        // ...
        return  d; // assume it would work
    }
    var l = MakeList();
    l.Add(BaseClass); // now we added object of BaseClass to the list that expects object of DerivedClass, any operation on the original list (the one with List<DerivedClass> type could break
