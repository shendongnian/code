    IKernel kernel = new StandardKernel(new AutoModule());
    kernel.Bind<Inspector>().ToSelf();
    
    class Inspector
    {
          IVehicle[] vehicles;
          public Inspector(IVehicle[] vehicles)
          {
              this.vehicles=vehicles;
          }
          public void PrintSpecifications()
          {
               foreach(var v in vehicles )
               {
                  v.PrintSpecification();
                }
          }
    }
    //automatic injection in constructor
    kernel.Get<Inspector>().PrintSpecifications();
