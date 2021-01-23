    public abstract class MyGenericControl<T> : WebControl {
       ...
       public T SomeStronglyTypedProperty { get; set; }
       protected MyGenericControl(...) {
          ...
       }
       ...
    }
    public sealed class MyConcreteControl : MyGenericControl<SomeType> {
       public MyConcreteControl()
       : base(
          ...
       ) {
       }
    }
