    private void btnAdd_Click(object sender, EventArgs e)
    {
        LabEntity selectedItem = bindingSource1.Current as LabEntity;
        RemoveItemFromList(selectedItem);
    }
    private void btnRemove_Click(object sender, EventArgs e)
    {
        LabEntity selectedItem = bindingSource2.Current as LabEntity;//new binding source
        RemoveItemFromList(selectedItem);
    }
	
	private void RemoveItemFromList(LabEntity ent)
	{
		selectedLabsData.Add(ent);
        availableLabsData.Remove(ent);
	}
