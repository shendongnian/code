    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int minutes = int.Parse(e.Row.Cells[YourColumnIndex].Text);
    		    decimal hours = minutes / 60;		
    		    e.Row.Cells[YourColumnIndex].Text = hours.ToString();
    	    }
        }
	
