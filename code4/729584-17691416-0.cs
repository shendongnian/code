    public class GenericFoo<TFrom, TTo>
        where TFrom : MyExtendedType
        where TTo : MyType
    {
       public TTo GenericFoo(TFrom A)
       {
          return (TTo)A.Bar();
       }
    }
