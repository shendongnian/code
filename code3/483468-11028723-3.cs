    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _Source;
        public ReadOnlyDictionary(IDictionary<TKey, TValue> source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            _Source = source;
        }
        // ToDo: Implement all methods of IDictionary and simply forward
        //       anything to the _Source, except the Add, Remove, etc. methods
        //       will directly throw an NotSupportedException.
    }
