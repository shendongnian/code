    public class SportCarMap : SubclassMap<Car>
    {
        public SportCarMap()
        {
            DiscriminatorValue("SportCar");
            //If your Sport Car has specific properties:
            //Map(x => x.BrakeHorsePower);
        }
    }
    public class TruckMap : SubclassMap<Car>
    {
        public TruckMap()
        {
            DiscriminatorValue("Truck");
            //If your Truck has specific properties:
            //Map(x => x.MaxLoad);
        }
    }
