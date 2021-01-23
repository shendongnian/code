    SyncField<T>
    {
        T O { get; private set; }
        T V { get; private set; }
    
        public bool HasChanged
        {
            get
            {
                if (V != null && O != null && O is ICollection)
                {
                    return ((ICollection)O).Count != ((ICollection)V).Count;
                }
                else
                {
                    return O != null && !O.Equals(V);
                }
            }
        }
    }
