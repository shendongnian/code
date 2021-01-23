    class MyReadOnlyKeyedCollection : MyKeyedCollection, IReadOnlyCollection<TValue> {
      MyKeyedCollection innerCollection;
 
      public MyReadOnlyKeyedCollection(MyKeyedCollection innerCollection) : base() {
        this.innerCollection = innerCollection;
      }
      protected override InsertItem(Int32 index, TItem item) {
        throw new NotSupportedException("This is a read only collection");
      }
      //Repeat for ClearItems(), RemoveItem(), and SetItem()
      public override void YourWriteMethod() {
        throw new NotSupportedException("This is a read only collection");
      }
      //Repeat for any other custom writable members
      protected override IList<T> Items { 
        get {
          return.innerCollection.ToList();
        }
      }
      //This should cover all other entry points for read operations
      public override Object YourReadMethod() {
        this.innerCollection.YourReadMethod();
      }
      //Repeat for any other custom read-only members
    
    }
