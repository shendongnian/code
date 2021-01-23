    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["test"] = "test1";
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx", true);
    }
    // adding this method to return view state
    public StateBag ReturnViewState()
    {
        return ViewState;
    }
