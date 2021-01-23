    private static bool ContainsOrdered<T>(IEnumerable<T> containing, IEnumerable<T> contained)
    {
        var e1 = containing.GetEnumerator();
        var e2 = contained.GetEnumerator();
        bool hasmore1 = e1.MoveNext();
        bool hasmore2 = e2.MoveNext();
        while (hasmore1 && hasmore2)
        {
            while (hasmore1 && !e1.Current.Equals(e2.Current))
                hasmore1 = e1.MoveNext();
            if (hasmore1) // Currents are equal
            {
                hasmore1 = e1.MoveNext();
                hasmore2 = e2.MoveNext();
            }
        }
        return !hasmore2;
    }
    bool contains1 = ContainsOrdered(l1, l3);
    bool contains2 = ContainsOrdered(l2, l3);
