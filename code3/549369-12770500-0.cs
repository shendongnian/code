    private void grdContactsView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
    {
    	_selectedContact = GetSelectedRow((DevExpress.XtraGrid.Views.Grid.GridView)sender);
    }
    
    private Contact GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView view)
    {
    	return (Contact)view.GetRow(view.FocusedRowHandle);
    }
