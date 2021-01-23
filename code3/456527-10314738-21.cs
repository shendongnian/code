    public static class BusinessObjectFactory
    {
         IocContainer _Container;
         public BusinessObjectFactory(IocContainer container)
         {
             this._Container = container;
         }
         public static T Create<T>()
         {
                return new BusinessObject(this._Container.Resolve<Dependency1>(), this._Container.Resolve<Dependency2>();
         }
       }
