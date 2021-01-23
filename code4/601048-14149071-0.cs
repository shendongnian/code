    protected override void OnDataChanged(bool rebuildVisibleColumns)
    {
        base.OnDataChanged(rebuildVisibleColumns);
        Dispatcher.BeginInvoke(new Action(() =>
        {
            this.FocusedRowHandle = GridControl.NewItemRowHandle;
        }), null);
    }
