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
    Because `Something` is type compatible with `object`, going by C# rules Otherwise the compiler prevents it. The actual cast is performed at run time which may or may not fail.
