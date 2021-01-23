    private static StandardKernel kernel;
    static void Main(string[] args)
    {
        Bootstrap();
        // Resolve the application's root type
        // by using the container directly.
        var farm = kernel.Get<Farm>();
        // Operate on the root type
        farm.Listen();
        Console.Read();
    }
    private static Kernel Bootstrap()
    {
        kernel = new StandardKernel();
        kernel.Bind<IAnimal>().To<Dog>();
        kernel.Bind<IVehicle>().To<Tractor>();
        kernel.Bind<Farm>().ToSelf();
    }
