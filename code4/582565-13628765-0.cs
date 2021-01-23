    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       var source = (ContractControl)e.Item.DataItem;
       var destination = (ContractControl)e.Item.FindControl("contractControl");
       destination.ContractID = source.ContractID;
       destination.TileControl = source.TileControl;
       destination.DetailControl = source.DetailControl;
    }
