    public class MyGenericClass<T, TBase> 
      where T : TBase
    { 
      public void DoSomething(List<TBase> things) 
      {
        ...
      }
    }
    public class MyGenericClass<T> : MyGenericClass<T, T>
    {
      ...
    }
