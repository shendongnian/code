    LapsList.Sort
    (
        delegate(Tuple<DateTime, String> p1, Tuple<DateTime, String> p2)
        {
            return p1.Item1.CompareTo(p2.Item1);
        }
    );
