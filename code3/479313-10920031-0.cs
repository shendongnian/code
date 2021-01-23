    private void btnAdd_Click(object sender, EventArgs e)
    {
       SwapThem( bindingSource1, selectedLabsData, availableLabsData );
    }
    
    private void btnRemove_Click(object sender, EventArgs e)
    {
       SwapThem( bindingSource2, availableLabsData, selectedLabsData );
    }
    // I just don't know the proper type-cast of the "toAddTo" and "toRemoveFrom" parameters.
    private void SwapThem( BindingSource bs, List<yourType> toAddTo, List<yourType> toRemoveFrom )
    {
       LabEntity selectedItem = bs.Current as LabEntity;
       toAddTo.Add(selectedItem);
       toRemoveFrom.Remove(selectedItem);
    }
