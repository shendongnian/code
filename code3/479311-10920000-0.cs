    private void ListFixup(object entity, List<Item> addList, List<Item> removeList)
    {
        LabEntity selectedItem = entity as LabEntity;
        // don't forget your error checking here
        addingList.Add(selectedItem);
        removingList.Remove(selectedItem);
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        ListFixup(bindingSource1.Current, selectedLabsData, availableLabsData);
    }
    private void btnRemove_Click(object sender, EventArgs e)
    {
        ListFixup(bindingSource2.Current, availableLabsData, selectedLabsData);
    }
