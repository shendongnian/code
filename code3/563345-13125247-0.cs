    // As is: Won't work, because there is no way to refer to the constructed
    // specific type of ItemBase:
    public class ListHandler<TList> where TList: ListBase {
        public TList List { get; private set; }
        public ListHandler(TList List) { this.List = List; }
        public void AddItem(T???? item) { List.ListExample.Add(item); }
    }
    
    // Corrected: this will work because TItem can be used to constrain
    // the constructed ListBase type as well:
    public class ListHandler<TItem> where TItem : ItemBase {
        public ListBase<TItem> List { get; private set; }
        public ListHandler(ListBase<TItem> List) { this.List = List; }
        public void AddItem(TItem item) { List.ListExample.Add(item); }
    }
    // And this will work just fine:
    var handler = new ListHandler<FooItem>(new FooList());
