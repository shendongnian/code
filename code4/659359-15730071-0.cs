    public static void Entry()
    {           
        unityContainer.RegisterType<ICarRepository, CarRepository>(
            new HierarchicalLifetimeManager());
        var carShop = new CarShop();
        carShop.BuyCar();
    }
    
    private void CheckCar()
    {
        using (var childContainer = unityContainer.CreateChildContainer())
        {
            var carService = childContainer.Resolve<CarService>();
            var car = carService.GetCar(1);            
        }
        // **Dispose() method is not called out of this scope**
    }
