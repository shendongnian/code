    class PairList<T1, T2> : IEnumerable
    {
        private List<Pair<T1, T2>> _list = new List<Pair<T1, T2>>();
    
        public void Add(T1 arg1, T2 arg2)
        {
            _list.Add(new Pair<T1, T2>(arg1, arg2));
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
