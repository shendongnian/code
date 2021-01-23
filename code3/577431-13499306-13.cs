    public class NewRelicIgnoreTransactionOwinModule
    {
        private AppFunc _nextAppFunc;
 
        public NewRelicIgnoreTransactionOwinModule(AppFunc nextAppFunc)
        {
            _nextAppFunc = nextAppFunc;
        }
 
        public Task Invoke(IDictionary<string, object> environment)
        {
            // Tell NewRelic to ignore this particular transaction
            NewRelic.Api.Agent.NewRelic.IgnoreTransaction();
     
            return _nextAppFunc(environment);
        }
    }
