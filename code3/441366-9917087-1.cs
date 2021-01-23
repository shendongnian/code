    interface IItem<U> {
      U SomeProperty { get; }
    }
    
    public class FirstObject<T, U> : IItem, IItem<U> {
      ...
    }
    
    List<IItem<U>> myList = ...
