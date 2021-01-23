    void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Item.ItemType == ListItemType.Item)
            {
                TextBox txtStartDate = e.Row.FindControl("txtStartDate") as TextBox;
                TextBox txtEndDate= e.Row.FindControl("txtEndDate") as TextBox;
                
                txtEndDate.Attributes.Add("onchange", "CompareDates('" + txtStartDate.Text + "', '" +txtEndDate.Text+ "');");
            }
    }
}
