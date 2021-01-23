    private void Delete()
    {
        IList<SampleDataItem> selectedItems = new List<SampleDataItem>();
        foreach (SampleDataItem item in itemGridView.SelectedItems)
        {
            selectedItems.Add(item);
        }
        var group = SampleDataSource.GetGroup("myGroup");
        foreach (SampleDataItem item in selectedItems)
        {
            group.Items.Remove(item);
        }
    }
