    class ThreeKeysDict<T1, T2, T3>
    {
        SortedList<Tuple<T1, T2, T3>, int> list = new SortedList<Tuple<T1,T2,T3>,int>();
        public void Add(T1 key1, T2 key2, T3 key3)
        {
            // TODO: check if key1 key2 or key3 do not exist (use binary search like in GetByKey1,2,3)
            list.Add(Tuple.Create(key1, key2, key3), 0);
        }
        public Tuple<T1, T2, T3> GetByKey1(T1 key1)
        {
            int index = this.list.Keys.BinarySearch(key1, x => x.Item1);
            return list.Keys[index];
        }
        public Tuple<T1, T2, T3> GetByKey2(T2 key2)
        {
            int index = this.list.Keys.BinarySearch(key2, x => x.Item2);
            return list.Keys[index];
        }
        public Tuple<T1, T2, T3> GetByKey3(T3 key3)
        {
            int index = this.list.Keys.BinarySearch(key3, x => x.Item3);
            return list.Keys[index];
        }
    }
