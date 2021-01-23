    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Product p = (e.Row.DataItem as Product);
            e.Row.Attributes.Add("onClick",  "location.href='somepage.aspx?id=" + p.ProductID + "'");
        }
    }
