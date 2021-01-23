    protected void Page_Init(object sender, EventArgs e)
    {
        MyControl1.LinkClicked += LinkClicked;
    }
    private void LinkClicked(object sender, EventArgs e)
    {
        //this is an AsyncPostBack;
    }
