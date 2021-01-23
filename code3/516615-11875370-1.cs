    public class LoggingStorage : IStorage
    {
        private readonly IStorage _proxied;
    
        public LoggingStorage(IStorage proxied)
        {
            _proxied = proxied;
        }
    
        public void Save(SomeObject toSave)
        {
           //log this call
           _proxied.Save(toSave);
        }
    
        public SomeObject Get(SomeId id)
        {
           //log this call
           return _proxied.Get(id);
        }
    }
