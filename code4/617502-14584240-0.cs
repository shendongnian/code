    public class LogDictionary: IDictionary<String, object>
    {
        DynamicTableEntity _dte;
        public LogDictionary(DynamicTableEntity dte)
        {
            _dte = dte;
        }
            bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
    
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return _dte.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
