    public static void Main(string[] args)
    {
        Car car = new Car();
        car.Brand = "Porsche";
        car.Color = "Yellow";
        Test(car);
    }
    public static void Test(Car value)
    {
       Console.WriteLine("This {0} has a {1} paint job", value.Brand, value.Color);
    }
