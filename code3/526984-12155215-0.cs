    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem ri = e.Item;
        DataRowView dr = (DataRowView)ri.DataItem;
        Panel Panel1 = (Panel)ri.FindControl("Panel1");
        // do your evaluation here according the values in the DataRowView     
        // use ri.FindControl("ID") to find controls in the Itemtemplate
    }
