    private void CommitNewForGrouping()
    {
        int num;   
        // !!! I believe it is None by default
        switch (this.NewItemPlaceholderPosition)
        {
            case NewItemPlaceholderPosition.AtBeginning:
                num = 1;
                break;
    
            case NewItemPlaceholderPosition.AtEnd:
                num = this._group.Items.Count - 2;
                break;
    
            default:
                // !!! Since you've not added groups -1 would be assigned to num
                num = this._group.Items.Count - 1;
                break;
        }
        int index = this._newItemIndex;
        object item = this.EndAddNew(false);
        // This method will call RemoveAt(num) where num == -1 in your case
        this._group.RemoveSpecialItem(num, item, false);
        this.ProcessCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, 
                 item, index));
    }
    internal void RemoveSpecialItem(int index, object item, bool loading)
    {
         ...
         // will fail since index always -1
         base.ProtectedItems.RemoveAt(index);
         ...
    }
