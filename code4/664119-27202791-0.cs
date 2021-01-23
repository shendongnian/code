    var container = new Container(x => x.Scan(scan =>
    {
        scan.TheCallingAssembly();
        scan.WithDefaultConventions();
        scan.AddAllTypesOf<IDiscountCalculator>();
    }));
    var strategy = container.GetInstance<IDiscountStrategy>();
    Console.WriteLine(strategy.GetDiscount("Regular", 10)); // 0
    Console.WriteLine(strategy.GetDiscount("Normal", 10)); // 1
    Console.WriteLine(strategy.GetDiscount("Special", 10)); // 5
