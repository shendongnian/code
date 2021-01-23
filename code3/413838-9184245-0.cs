    private static bool ContainsOrdered<T>(IEnumerable<T> containing, IEnumerable<T> contained)
    {
        var e1 = containing.GetEnumerator();
        var e2 = contained.GetEnumerator();
        bool hasmore1 = true;
        bool hasmore2 = false;
        while ((hasmore1 = e1.MoveNext()) && (hasmore2 = e2.MoveNext()))
        {
            while (hasmore1 && e1.Current.Equals(e2.Current))
                hasmore1 = e1.MoveNext();
        }
        return !hasmore2;
    }
    bool contains1 = ContainsOrdered(l1, l3);
    bool contains2 = ContainsOrdered(l2, l3);
