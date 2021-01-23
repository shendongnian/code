    public void ShowHideGridColumnBySortExpression(string sortExpression, bool show)
    {
    	for (int i = 0; i < gvProducts.Columns.Count; i++)
    	{
    		if (gvProducts.Columns[i].SortExpression != null && gvProducts.Columns[i].SortExpression == sortExpression)
    		{
    			gvProducts.Columns[i].Visible = show;
    			break;
    		}
    	}
    }
