        class MyTuple<T1, T2>
    {
        MyTuple() { }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public static implicit operator MyTuple<T1, T2>(Tuple<T1, T2> t)
        {
             return new MyTuple<T1, T2>(){
                          Item1 = t.Item1,
                          Item2 = t.Item2
                        };
        }
        public static implicit operator Tuple<T1, T2>(MyTuple<T1, T2> t)
        {
            return Tuple.Create(t.Item1, t.Item2);
        }
    }
