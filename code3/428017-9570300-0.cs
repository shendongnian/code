    class PairList<T1, T2> : IEnumerable<Pair<T1, T2>>
    {
        private List<Pair<T1, T2>> _list = new List<Pair<T1, T2>>();
    
        public void Add(T1 arg1, T2 arg2)
        {
            _list.Add(new Pair<T1, T2>(arg1, arg2));
        }
    
        public IEnumerator<Pair<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
