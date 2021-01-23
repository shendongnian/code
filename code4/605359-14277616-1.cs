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
