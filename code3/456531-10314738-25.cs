    public class ConcreteDataAccessFactory : IDataAccessFactory
    {
         IocContainer _Container;
         public ConcreteDataAccessFactory(IocContainer container)
         {
             this._Container = container;
         }
         public TDao Create<TDao>()
         {
                return (TDao)Activator.CreateInstance(typeof(TDao), this._Container.Resolve<Dependency1>(), this._Container.Resolve<Dependency2>())
         }
       }
