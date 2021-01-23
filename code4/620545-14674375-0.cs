    public class MyCollection : Collection<string>
    {
        private bool IsValidItem(string item)
        {
             return // Your condition : true if valid; false, otherwise.
        }
    
        // This method will be called when you call MyCollection.Add or MyCollection.Insert
        protected override InsertItem(int index, string item)
        {
            if(IsValidItem(item))
                base.InsertItem(index, item);
        }
    
        // This method will be called when you call MyCollection[index] = newItem
        protected override SetItem(int index, string item)
        {
            if(IsValidItem(item))
                base.SetItem(index, item);
        }
    }
