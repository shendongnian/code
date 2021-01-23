    protected void btnPost(object sender, EventArgs e)
    {
        //Your code for other operations
        //
        GridView GridView2 = (GridView)((GridViewRow)((Button)sender).NamingContainer).FindControl("GridView2");
        GridView2.DataSource = YourDataBasefetchingFunction();
        GridView2.DataBind() 
    }
