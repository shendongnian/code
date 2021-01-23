    public class CacheStoreEventArgs:eventargs
    {
        private IEnumerable<string> Data;//List<string> better
    
        public IEnumerable<string> data
        {
            get { return Data; }
            set { this.Data = value; }
        }
    
        public CacheStoreEventArgs(IEnumerable<string> NewData)
        {
            this.data = NewData;
        }
    }
