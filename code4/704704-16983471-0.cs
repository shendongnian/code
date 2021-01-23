      var query = CreatableTypes()
          .EndingWith("Service")
          .AsInterfaces();
      var serviceList = new List<BaseService>();
      foreach (var item in query)
      {
           var service = (BaseService)Mvx.IocConstruct(item.ImplementationType);
           serviceList.Add(service);
           foreach (var interfaceType in item.ServiceTypes)
           {
               Mvx.RegisterSingleton(interfaceType, service);
           }
      }
      foreach (var service in serviceList)
      {
           service.MyMethod();
      }
