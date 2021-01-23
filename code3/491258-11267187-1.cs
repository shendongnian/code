    class Program
    {
        static void Main(string[] args)
        {
            ExtendedCollection extendedCollection = new ExtendedCollection();
            extendedCollection.Add(new ExtendedItem { A = 1, B = 2, ReferenceToParentCollection = extendedCollection });
            extendedCollection.Add(new ExtendedItem { A = 3, B = 3, ReferenceToParentCollection = extendedCollection });
            foreach (ExtendedItem item in extendedCollection)
            {
                (item.ReferenceToParentCollection as ExtendedCollection) ...
            }
        }
    }
    public class FlexItem<T> where T : FlexItem<T>, new()
    {
        public object ReferenceToParentCollection;
    }
    public class FlexCollection<T> where T : FlexItem<T>, new()
    {
        public void Add(T item) { } 
    }
    public class BasicItem : FlexItem<BasicItem> { public int A; }
    public class BasicCollection : FlexCollection<BasicItem> { };
    public class ExtendedItem : BasicItem { public int B; }
    public class ExtendedCollection : FlexCollection<ExtendedItem> { };
