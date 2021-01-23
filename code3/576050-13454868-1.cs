    public class Deleter1Tests : DeleterTests<IRepository1>
    {
        protected override IDeleter CreateDeleter(IUnityContainer container)
        {
            return container.Resolve<Deleter1>();
        }
    }
    
    public class Deleter2Tests: DeleterTests<IRepository2>
    {
        protected override IDeleter CreateDeleter(IUnityContainer container)
        {
            return container.Resolve<Deleter2>();
        }
    }
