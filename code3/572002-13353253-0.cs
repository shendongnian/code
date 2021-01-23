    public class A<T>
    {
    }
    public void Foo<TItem, T>() where TItem : A<T>
    {
        var collectionA = new List<TItem>();
        var collectionB = new List<A<T>>(collectionA.ToArray()); 
    }
