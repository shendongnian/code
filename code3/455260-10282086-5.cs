    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private YourEntities _dataContext;
        public YourEntities Get()
        {
            return _dataContext ?? (_dataContext = new YourEntities());
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
