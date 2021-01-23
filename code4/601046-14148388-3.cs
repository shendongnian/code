    private void MVVMFriendlyDxgTableView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e) 
    {
        if (e.RowHandle == GridControl.NewItemRowHandle)
        {
            Dispatcher.BeginInvoke(new Action(() => { viewSource.View.MoveCurrentToLast(); }));
            Dispatcher.BeginInvoke(new Action(() => { gridView.FocusedRow = e.Row; }));
            e.Handled = true;
        }
    }
