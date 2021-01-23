    private void SelectNew(DataGridViewColumnCollection collection, int index)
    {
        ClearSelection();
        collection[index].Selected = true;
    }
    private void SelectNew(DataGridViewRowCollection collection, int index)
    {
        ClearSelection();
        collection[index].Selected = true;
    }
