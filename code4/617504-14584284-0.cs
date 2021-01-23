    public class LogDictionary: IDictionary<String, object>
    {
        private IDictionary<String, object> _dte;
        public LogDictionary(DynamicTableEntity dte)
        {
            _dte = (IDictionary<String, object>)dte;
        }
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return _dte.Remove(item.Key);
        }
    
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return _dte.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
