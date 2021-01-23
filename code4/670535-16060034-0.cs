    void dgData_Sorting(object sender, DataGridSortingEventArgs e)
    {
        // reset sortings
        collection.SortDescriptions.Clear();
            
        // define column sort
        e.Column.SortDirection = e.Column.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            
        // sort collection
        collection.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, e.Column.SortDirection.GetValueOrDefault()));
        // mark event as handled otherwise the datagrid will "reset" your custom sorting
        e.Handled = true;
    }
