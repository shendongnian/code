    IEnumerable<MyBaseClass> EnumerateWithOptions(Type optionalDerivedClass = null)
    {
        if (optionalDerivedClass == null)
            return MyCustomCollection();
        return MyCustomCollection()
            .Where(thingy => thingy.GetType() == optionalDerivedClass);
    }
