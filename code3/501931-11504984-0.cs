    protected virtual void PageSize_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        ViewState["PageSize"] = Convert.ToInt32(lnk.CommandArgument);
        
        BindGridView();        
    }
    private void BindGridView()
    {
        // Treat as psuedo-code. May take some tweaking with casting.
        myGridView.PageSize = ViewState["PageSize"]; 
        MyDataType data = MyDataLayer.GetData();
        myGridView.DataBind();        
    }
