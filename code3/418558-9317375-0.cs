    public interface IFactory<out T>
    {
        T CreateInstance();
    }
    public class GenericClass<T>
    {
         private readonly IFactory<T> _factory;
         public GenericClass(IFactory<T> factory)
         {
              _factory = factory;
         }
         public DoSomething()
         {
              //...
              T foo = _factory.CreateInstance();
              //...
         }
    }
