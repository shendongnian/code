    public interface INextable<T>
    {
      public T Next {get;set;}
    }
    List<MyClass> list = new List<MyClass>(); // Where MyClass implements INextable<MyClass>
    var query = list.Zip(list.Skip(1), (a, b) => new
    {
        First = a,
        Second = b
    });
    
    foreach (var item in query)
    {
        item.First.Next = item.Second;
    }
