    private void SelectDataGridItem(Model.MyEntityType selectedItem)
    {
    	foreach (DataGridViewRow row in MyDataGrid.Rows)
    	{
    		var boundItem = (Model.MyEntityType) row.DataBoundItem;
    		if (boundItem.Id == selectedItem.Id)
    		{
    			row.Selected = true;
    			break;
    		}
    	}
    }
