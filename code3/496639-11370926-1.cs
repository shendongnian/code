    Car
    {
        Brand brand;
    }
    CarPrinter
    {
        Car carToPrint;
        static CreatePrinter(Car car)
        {
            return car.Brand() == PorscheBrand() ? new PorscheCarPrinter(car) : new DefaultCarPrinter(car);
        }
    }
    PorscheCarPrinter
    {
        Print();
    }
    DefaultCarPrinter
    {
        Print();
    }
