    public interface IFoo<T>
    {
      void DoStuff(T value);
    }
    
    public class MyClass : IFoo<MyClass.NestedInMyClass>
    {
      void IFoo<MyClass.NestedInMyClass>.DoStuff(MyClass.NestedInMyClass value)
      {
      }
      private class NestedInMyClass
      {
      }
    }
