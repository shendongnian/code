    protected void grdDummy_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Collect the texts from the column headers
    	if (e.Row.RowType == DataControlRowType.Header)
    	{ 
    		for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
    		{
    			this._headers.Add(e.Row.Cells[i].Text);
    		}
    	}
    
        if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
    		{
    			if (TryToParse(e.Row.Cells[i].Text) > 0)
    			{
    				string rowKey = e.Row.Cells[0].Text;
    				string column = this._headers[i];
					
    				HyperLink link = new HyperLink();
    				link.Text = e.Row.Cells[i].Text;
    				link.NavigateUrl="page.aspx?key=" + rowKey  + "&column=" +column;
    
    				e.Row.Cells[i].Controls.Clear();
    				e.Row.Cells[i].Controls.Add(link);
    			}
    		}
    	}
    }
