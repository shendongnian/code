    private void CommitNewForGrouping()
    {
        int num;
        
       ...
        /// always returns -1 in your case!
        int index = this._newItemIndex;
        object item = this.EndAddNew(false);
        // !!!
        this._group.RemoveSpecialItem(num, item, false);
        ...
    }
    internal void RemoveSpecialItem(int index, object item, bool loading)
    {
         ...
         // will fail since index always -1
         base.ProtectedItems.RemoveAt(index);
         ...
    }
