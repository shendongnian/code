    public static void Handle(
        IEnumerable<T> source,
        Action<T> catchAll,
        params Func<T, bool>[] handlers)
    {
        foreach (T t in source)
        {
            int i = 0; bool handled = false;
            while (i < handlers.Length && !handled)
                handled = handlers[i++](t);
            if (!handled) catchAll(t);
        }
    }
    // e.g.
    public bool handleP(int input, int p)
    {
        if (input % p == 0)
        {
            Console.WriteLine("{0} is a multiple of {1}", input, p);
            return true;
        }
        return false;
    }
    Handle(
        source,
        i => { Console.WriteLine("{0} has no small prime factor"); },
        i => handleP(i, 2),
        i => handleP(i, 3),
        ...
        );
