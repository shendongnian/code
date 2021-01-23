    private List<string> _listOfStrings
    {
       get
       {
         return (List<string>)Session["_listOfStrings"];
       }
       set
       {
         Session["values"] = value;   
       }
    }
    
    protected override OnInit( EventArgs e )
    {
        if( !Page.IsPostback )
        {
            _listOfStrings = new List<string>();
        }
    
        BuildControlTree();
    }
    
    private void BuildControlTree()
    {
       foreach( string s in _listOfStrings )
       {
         // add a control to the control tree
       }
    }
    
    protected void btnAddItem_Click( object sender, EventArgs e )
    {
        _listOfStrings.Add( "some new item" );
    
        // insert the control into the tree
    }
