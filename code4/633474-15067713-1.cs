    /// <summary>
    /// Inserts a item at the specified index
    /// </summary>
    ///<param name="index">The index where the item should be inserted</param>
    ///<param name="item">The item which should be inserted</param>
    protected override void InsertItem(int index, T item)
    {
        DoDispatchedAction(() => base.InsertItem(index, item));
    }
