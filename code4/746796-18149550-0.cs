    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
          //Populate information.
       }
    }
    
    protected void chkSomething_Changed(object sender, EventArgs e)
    {
       //Do checkbox stuff
    }
    
    protected void btnSomething_Clicked(object sender, EventArgs e)
    {
       //Update.... You don't need to check postback here. It's a postback, you know this because you caused it.
    }
