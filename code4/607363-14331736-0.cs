    class Sample<T>
    {
        public delegate TOut GetValueDefault<in TIn, TOut>(string key, TIn defaultValue);
        private GetValueDefault<T, T> getValueDefault = null; 
        public Sample(GetValueDefault<T, T> del)
        {
            getValueDefault = del;
        }
    }
 
