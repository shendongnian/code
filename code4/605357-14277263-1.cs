    IKernel kernel = new StandardKernel(new AutoModule());
    IVehicle v1 = kernel.Get<IVehicle>("Small");
    IVehicle v2 = kernel.Get<IVehicle>("Huge");
    IVehicle v3 = kernel.Get<IVehicle>("Big");
    v1.PrintSpecification();
    v2.PrintSpecification();
    v3.PrintSpecification();
