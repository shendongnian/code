    public class DictionaryWithDefault<T1,T2> : Dictionary<T1,T2>
    {   
        private T2 t2Default;
        public new T2 this[T1 t1]
        {   // indexer - if the key is not present return the default
            get
            {
                T2 t2t;
                return TryGetValue(t1, out t2t) ? t2t : t2Default;
            }
        }
        public DictionaryWithDefault(T2 _t2) { this.t2Default = _t2; }
    }
