    public static void Main(string[] args)
    {
         var vehicleFactory = new VehicleFactory();
         var vehicle = vehicleFactory.CreateVehicle<Car>();
    }
