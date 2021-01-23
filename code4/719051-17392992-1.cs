    public class Foo {
        // pre .NET 4.5, use ReadOnlyCollection<T> (which implements IList<T>)
        public static readonly IReadOnlyList<long> myList = new List<long> { 1, 2, 3 }.AsReadOnly();
    }
    
    var testList = Foo.myList.ToList(); // get an editable copy
    var testList2 = Foo.myList; // get a reference to the immutable static list
