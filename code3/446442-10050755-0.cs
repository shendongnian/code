    protected override void OnLoad( EventArgs e)
    {
        // build every time the page loads
        BuildTree();
    }
    
    private void BuildTree()
    {
        if( [state exists] )
        {
            // create controls
        }
        
        // otherwise, do nothing
    }
    
    protected void btnDoSomething_Click( object sender, EventArgs e )
    {
        // 1. Use user input to create data model and store it somewhere
    
        // simple example:
    
        // get the value from the user
        int i = Convert.ToInt32( this.txtFoo.Text );
    
        // store it in session
        Session["Number"] = i;
        
        // 2. rebuild your tree of controls
        BuildTree();
    }
