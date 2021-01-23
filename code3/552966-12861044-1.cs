    public class ChangedEventArgs<T> : EventArgs
    {
        public readonly T? ChangedItem;
        public readonly ChangeType ChangeType;
        public readonly T? ReplacedWith;
        public ChangedEventArgs(ChangeType change, T? item,
            T? replacement)
        {
            ChangeType = change;
            ChangedItem = item;
            ReplacedWith = replacement;
        }
    }
    public enum ChangeType
    {
        Added,
        Removed,
        Replaced,
        Cleared
    };
    class CollectionChangeTracked<T> : Collection<T> where T : struct
    {
        public event EventHandler<ChangedEventArgs<T>> Changed;
        protected override void InsertItem(int index, T newItem)
        {
            base.InsertItem(index, newItem);
            EventHandler<ChangedEventArgs<T>> temp = Changed;
            if (temp != null)
            {
                temp(this, new ChangedEventArgs<T>(
                    ChangeType.Added, newItem, default(T)));
            }
        }
        protected override void SetItem(int index, T newItem)
        {
            T replaced = Items[index];
            base.SetItem(index, newItem);
            EventHandler<ChangedEventArgs<T>> temp = Changed;
            if (temp != null)
            {
                temp(this, new ChangedEventArgs<T>(
                    ChangeType.Replaced, replaced, newItem));
            }
        }
        protected override void RemoveItem(int index)
        {
            T removedItem = Items[index];
            base.RemoveItem(index);
            EventHandler<ChangedEventArgs<T>> temp = Changed;
            if (temp != null)
            {
                temp(this, new ChangedEventArgs<T>(
                    ChangeType.Removed, removedItem, null));
            }
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            EventHandler<ChangedEventArgs<T>> temp = Changed;
            if (temp != null)
            {
                temp(this, new ChangedEventArgs<T>(
                    ChangeType.Cleared, null, null));
            }
        }
    }
