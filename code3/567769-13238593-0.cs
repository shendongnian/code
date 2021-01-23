    public class VehicleFactory
    {
        protected Dictionary<Type, ISpecificTransportFactory> _mapping = // initialize
        public Vehicle CreateVehicle<TVehicle>() // any params
        {
            if(_mapping.ContainsKey(typeof(TVehicle))
              return _mapping[typeof(TVehicle)].CreateVehicle(); // any params that need to be passed
            throw new ConfigurationInvalidException("No transportFactory defined for : " + typeof(TVehicle).Name);
        }
    }
