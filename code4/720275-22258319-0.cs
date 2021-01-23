    public abstract class BaseClass<TDerived> : where TDerived: BaseClass<TDerived>
    {
       public TDerived DoSomethingCommon(string param)
       {
          var derivedType = (TElement)this;
          //do something.
          return derivedType;
       }
    }
