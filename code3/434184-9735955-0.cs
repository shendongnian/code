    public abstract class A{
       protected virtual void SetValue(object value);
       public object SomeObject{
          set{SetValue(value);}
       }
    }
