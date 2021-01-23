    public interface IAbstractContainer
    {
      T Resolve<T>();
    }
    
    public class ConcreteContainer: IAbstractContainer
    {
      private IContainer _container; // E.g. Autofac container
    
      public ConcreteContainer(IContainer container)
      {
        _container = container;
      {
    
      public T Resolve<T>()
      {
        return _container.Resolve<T>();
      }
    }
    
    public classA(IAbstractContainer container)
    {
      this.B = container.Resolve<ClassB>();
      this.C = container.Resolve<ClassC>();
      ...
    }
