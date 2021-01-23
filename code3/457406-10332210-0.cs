    public static void Do<T1, T2, T3>(this Tuple<T1, T2, T3> tuple,
                                      Action<T1, T2, T3> action)
    {
        action(tuple.Item1, tuple.Item2, tuple.Item3);
    }
