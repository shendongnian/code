    class Program
    {
        static void Main(string[] args)
        {
            BasicCollection extendedCollection = new BasicCollection();
            extendedCollection.Add(new ExtendedItem { A = 1, B = 2});
            extendedCollection.Add(new BasicItem { A = 3 });
            extendedCollection.Add(new ExtendedItem { A = 4, B = 5});
            
            foreach (BasicItem item in extendedCollection)
            {
                switch(item.GetType().Name)
                {
                    case "BasicItem":
                        Console.Out.WriteLine(string.Format("Found BasicItem: A={0}", item.A));
                        break;
                    case "ExtendedItem":
                        ExtendedItem extendedItem = item as ExtendedItem;
                        Console.Out.WriteLine(string.Format("Found ExtendedItem: A={0} B={1}", extendedItem.A, extendedItem.B));
                        break;
                }
            }
        }
    }
    public class FlexItem<T> where T : FlexItem<T>, new()
    {
        public FlexCollection<BasicItem> ReferenceToParentCollection;
    }
    public class FlexCollection<T> where T : FlexItem<T>, new()
    {
        public void Add(T item) { } 
    }
    public class BasicItem : FlexItem<BasicItem> { public int A; }
    public class ExtendedItem : BasicItem { public int B; }
    public class BasicCollection : FlexCollection<BasicItem>
    {
        Collection<BasicItem> items = new Collection<BasicItem>();
        public void Add(BasicItem item)
        {
            item.ReferenceToParentCollection = this;
            items.Add(item);
        }
        public void Remove(BasicItem item)
        {
            item.ReferenceToParentCollection = null;
            items.Remove(item);
        }
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
