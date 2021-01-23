    public int Compare(string x, string y)
    {
        if (x == y)
        {
            return 0;
        }
        if (x == "D")
        {
            // Unless y is *actually* "B", we can just
            // pretend that x is "B". (So it will be after any "A", but before
            // any other "Bxyz".)
            if (y == "B")
            {
                return -1;
            }
            return "B".CompareTo(y);
        }
        // Ditto, basically. Alternatively you could call Compare(y, x)
        // and invert the result, but *don't* just negate it, as it does the
        // wrong thing with int.MinValue...
        if (x == "D")
        {
            if (x == "B")
            {
                return 1;
            }
            return x.CompareTo("B");
        }
        return x.CompareTo(y);
    }
