    public class BaseClass<T>  where T : new()
    {   
       public T SomeMethod()
       {
          return new T();
       }
    }
    public class SubClass<T> : BaseClass<T> where T : new() 
    {...}
