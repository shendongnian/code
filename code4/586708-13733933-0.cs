    public IEnumerable<MyBaseClass> EnumerateWithOptions(Type optionalDerivedClass = null)
    {
        foreach (MyBaseClass thingy in MyCustomCollection())
        {
            if (thingy.GetType() == (optionalDerivedClass ?? typeof(MyBaseClass)))
                  yield return thingy;
        }
    }
