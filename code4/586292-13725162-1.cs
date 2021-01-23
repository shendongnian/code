    public class TimeSeries<T> : ITimeSeries<T>
    {
        private List<List<T>> _Data;
    
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            // check for nulls, etc.
            return _Data.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
