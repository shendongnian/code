    protected void Page_Init(object sender, EventArgs e)
    {
       gw.RowDeleting += new GridViewDeleteEventHandler(gw_RowDeleting);
    }
    
    void gw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       // do whatever you want
    }
