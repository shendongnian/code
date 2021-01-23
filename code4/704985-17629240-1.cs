    private void outerGrid_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
    {
    	DataGrid dg = sender as DataGrid;
    	if (dg != null)
    	{
    		if (dg.CurrentCell != null && dg.CurrentCell.Column.Header.ToString() == "Name")
    		{                    
    			e.DetailsElement.Visibility = System.Windows.Visibility.Collapsed;
    		}
    		else
    		{   
    			e.DetailsElement.Visibility = System.Windows.Visibility.Visible;
    		}
    	}
    }
