    class ThreeTupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        public void Add(T1 a, T2 b, T3 c)
        {
            this.Add(new Tuple<T1, T2,T3>(a, b, c));
        }
    }
