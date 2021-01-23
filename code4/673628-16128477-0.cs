    public interface IStateProvider
    {
        void Store( string key, object value );
        object Get( string key );
    }
    
    public class StateProvider : IStateProvider
    {
        private static ConcurrentDictionary<string, object> _storage = new ConcurrentDictionary<string, object>();
    
        public void Store( string key, object value )
        {
            // add to storage
        }
    
        public object Get( string key )
        {
            // get from storage
        }
    }
    
    public class Forest<T1, T2>
    {
        private IStateProvider _stateProvider;
        
        public Forest( IStateProvider stateProvider )
        {
            _stateProvider = stateProvider;
        }
    
        public void Foo()
        {
            // do something with the stateful value
        }
    }
    // of course, you could do this with a DI framework
    var stateProvider = new StateProvider();
    var forest = new Forest<Foo, Bar>( stateProvider );
