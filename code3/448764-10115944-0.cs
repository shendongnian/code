    internal abstract class BaseClass
    {
       protected object mValue; // could also be defined as a T in BaseClass<T>
       public object GetColumn4Data { get { return mValue; } }
    }
    // this is a group of classes with varying type
    internal abstract class BaseClass<T> : BaseClass
    {
       public T GetTypedColumn4Data 
       {
          get { return (T)mValue; } 
          set { mValue = value; }
       }
    }
    // these are not really necessary if you don't plan to extend them further
    // in that case, you would mark BaseClass<T> sealed instead of abstract
    internal sealed class BoolSubClass : BaseClass<bool>
    {
       // no override necessary so far
    }
    internal sealed class StringSubClass : BaseClass<string>
    {
       // no override necessary so far
    }
