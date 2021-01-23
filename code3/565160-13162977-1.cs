    public static void TestCars2()
    {
        Car[] cars = new Car[3];
        cars[0] = new Car();
        cars[1] = new ConvertibleCar();
        cars[2] = new Minivan();
    }
    foreach (Car vehicle in cars)
    {
        System.Console.WriteLine("Car object: " + vehicle.GetType());
        vehicle.DescribeCar();
        System.Console.WriteLine("----------");
    }
