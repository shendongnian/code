    protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
    {
        base.OnColumnAdded(e);
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
    }
