    enum State
    {
        Unknown,
        Important,
        Updated,
        Deleted,
        Other
    }
    void run()
    {
        IEnumerable<State> test1 = new[]
        {
            State.Important, 
            State.Updated, 
            State.Other, 
            State.Unknown
        };
        if (test1.AllPredicatesTrueOverall(s => s == State.Important, s => s == State.Updated))
            Console.WriteLine("test1 passes.");
        else
            Console.WriteLine("test1 fails.");
        IEnumerable<State> test2 = new[]
        {
            State.Important, 
            State.Other, 
            State.Other, 
            State.Unknown
        };
        if (test2.AllPredicatesTrueOverall(s => s == State.Important, s => s == State.Updated))
            Console.WriteLine("test2 passes.");
        else
            Console.WriteLine("test2 fails.");
        // And to show how you can use any number of predicates:
        bool result = test1.AllPredicatesTrueOverall
        (
            state => state == State.Important,
            state => state == State.Updated,
            state => state == State.Other,
            state => state == State.Deleted
        );
    }
