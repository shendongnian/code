    using(IEnumerator iterator1 = args.GetEnumerator())
    using (IEnumerator iterator2 = args.GetEnumerator())
    {
        while (iterator1.MoveNext() | iterator2.MoveNext())
        {
            //do stuff
        }
    }
