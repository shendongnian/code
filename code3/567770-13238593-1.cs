    public interface ISpecificTransportFactory
    {
         Vehicle CreateVehicle();
    }
    public abstract class FactoryBase<TVehicleType> : ISpecificTransportFactory
        where TVehicleType : Vehicle
    {
        public Vehicle CreateVehicle()
        {
            return CreateInstance();
        }
        public abstract TVehicleType CreateInstance();
    }
    public class CarFactory : FactoryBase<Car>
    {
         public override Car CreateInstance()
         {
              return new Car();
         }
    }
