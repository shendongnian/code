    private void dgOrderContents_LoadingRow(object sender, DataGridRowEventArgs e)
    {
    	foreach (DataGridColumn col in dgOrderContents.Columns)
    	{
    		if (col.Header.ToString() == "Thumb")
    		{
    			PhotoComponentForDataGrid pcdControl = (PhotoComponentForDataGrid)col.GetCellContent(e.Row);
    			pcdControl.PopupTarget= this.LayoutCanvas;
    		}
    	}
    }
