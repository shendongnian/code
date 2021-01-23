    public abstract class BasicComponent<T>
    {
      public T Build()
      {
        return new T();//can't do this without `new()` constraint.
      }
      public bool Check(T item)
      {
        return item != null;//only references types can be null, so 
                            //can't do this without `class` constraint
                            //though notice that `default(T)` works for
                            //both reference and value types.
      }
      public bool IsSame(T x, T y)
      {
        return ReferenceEquals(x, y);//pointless with value-types.
      }
      public abstract void Whatever();//just added in so the class still does something abstractly!
    }
