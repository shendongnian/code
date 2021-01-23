    class MyCollection:Collection<T>
    {
        private void ValidateItem(T item)
        {
           if(item is invalid)
             throw new ArgumentException("Item is invalid");
        }
        protected override InsertItem(int index, T item)
        {
            ValidateItem(item);
            base.InsertItem(index, item);
        }
        protected override SetItem(int index, T item)
        {
            ValidateItem(item);
            base.SetItem(index, item);
        }
    }
