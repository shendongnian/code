    public class Factories
    {
        private Dictionary<Type, object> _factories;
        public Factories()
        {
            _factories = new Dictionary<Type, object>();
            _factories[typeof (Engine)] = new EngineFactory();
        }
        public IFactory<TPart> GetFactory<TPart>() where TPart:IPart
        {
            //TODO: add check whether typeof(TPart) exist in the dictionary
            return (IFactory<TPart>)_factories[typeof(TPart)];
        }
    }
