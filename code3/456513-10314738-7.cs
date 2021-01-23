    public static class BusinessObjectFactory
    {
         public static T Create<T>()
         {
                return new BusinessObject(this._Conainer.Resolve<Dependency1>(), this._Container.Resolve<Dependency2>();
         }
       }
