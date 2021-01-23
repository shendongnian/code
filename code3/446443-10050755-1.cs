    protected override void OnLoad( EventArgs e)
    {
        // build every time the page loads
        BuildTree();
    }
    
    private void BuildTree()
    {
        // clear existing dynamic controls
        this.MyOutputPanel.Controls.Clear();
        // if there is a value in session, use it
        if( Session["Number"] != null )
        {
            int number = (int)Session["Number"];
            // create some dynamic controls
            for( int i = 0; i < number; i++ )
            {
                var div = new HtmlGenericControl( "div" );
                this.MyOutputPanel.Controls.Add( div );
            }
        }
        
        // otherwise, do nothing
    }
    
    protected void btnDoSomething_Click( object sender, EventArgs e )
    {
        // 1. Get the value from the user and store it in Session
        Session["Number"] = Convert.ToInt32( this.txtFoo.Text );
        // 2. rebuild your tree of controls
        BuildTree();
    }
