    /// <summary>
    /// Removes selected items from the IEditableCollection
    /// </summary>
    public void RemoveSelectedRows()
    {
    	var item = CurrentItem as IEditableBusinessObject;
    
    	// if row is not valid, cancel rather than commit to avoid validation
    	if (item != null)
    	{
    		item.CheckRules();
    
    		if (!item.IsValid)
    			this.CancelEdit();
    		else
    			this.CommitEdit();
    	}
    	else
    	{
    		this.CommitEdit();
    	}
    
    	//			_lastErrorRow = -1;
    
    	if (SelectedItems.Count == 0)
    	{
    		MsgBox.ShowMsg(SharedResources._PleaseSelectRowFirst);
    		return;
    	}
    
    	var col = ItemsSource as Csla.Core.IEditableCollection;
    	if (col != null)
    	{
    		var deleteItems = SelectedItems.OfType<IEditableBusinessObject>().ToList();
    
    		int i = 0;
    		while (i < deleteItems.Count)
    		{
    			col.RemoveChild(deleteItems[i]);
    		}
    	}
    }
