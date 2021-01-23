    class UniqueList<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            if (!base.Contains(item))
            {
                base.InsertItem(index, item);
            }
            else
            {
                // whatever
            }
        }
    }
