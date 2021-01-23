        class SomethingEnumerator
        {
            public object Current //returns object this time
            {
                get { return ... }
            }
            public bool MoveNext()
            {
            }
        }
    You could write:
        foreach (Something thing in new Test())
        {
        
        }
    Because `Something` is type compatible with `object`, going by C# rules ,or in other words, the compiler lets it if there is an explicit cast possible between the two types. Otherwise the compiler prevents it. The actual cast is performed at run time which may or may not fail.
