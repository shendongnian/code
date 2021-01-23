    public class DictionaryWithDefault<T1,T2> : Dictionary<T1,T2>
    {
        private T2 t2;
        public new T2 this[T1 t1]
        {
            get
            {
                T2 t2t;
                return TryGetValue(t1, out t2t) ? t2t : t2;
            }
        }
        public DictionaryWithDefault(T2 _t2) { this.t2 = _t2; }
    }
