    void gridview_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
    
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
    string theValue = e.Row.Cells[3].Text;
    
    if (theValue ="M")
    {
    e.Row.Cells[1].Forecolor= Color.Red
    }
    
    else if (theValue ="F")
    {
    e.Row.Cells[1].Forecolor= Color.Blue;
    }
    }
    }
