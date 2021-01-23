    public class Company
    {
        private Dictionary<Type, dynamic> _factories;
        public Company()
        {
            _factories = new Dictionary<Type, dynamic>();
            _factories[typeof(Engine)] = new EngineFactory();
        }
        public void SendOrderIntakeToFactory(IPart part)
        {
            _factories[part.GetType()].Produce((dynamic)part);
        }
    }
