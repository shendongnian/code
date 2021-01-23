    private void btnAdd_Click(object sender, EventArgs e)
    {
        LabsDataAdded(bindingSource1.Current as LabEntity);
    }
    private void btnRemove_Click(object sender, EventArgs e)
    {
        LabsDataRemoved(bindingSource2.Current as LabEntity);
    }
