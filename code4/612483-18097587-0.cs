    gridColumn.ColumnEdit = new RepositoryItemHyperLinkEdit();
    gridColumn.OptionsColumn.ReadOnly = true;
    gridColumn.OptionsColumn.AllowEdit = false;
    
    gridView.MouseUp += gridView_MouseUp;
    
    private void gridViewDesk_MouseUp(object sender, MouseEventArgs e)
    {
    	GridView gridView = (GridView) sender;
    	if (e.Button == MouseButtons.Left && e.Clicks == 1)
    	{
    		GridHitInfo hitInfo = gridView.CalcHitInfo(e.Location);
    		if (hitInfo.InRowCell && hitInfo.Column == this.gridColumn)
    		{
    			MessageBox.Show("Click " + hitInfo.RowHandle);
    		}
    	}
    }
