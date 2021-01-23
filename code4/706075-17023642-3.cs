    protected void Page_Load(object sender, EventArgs e)
    {
        WebUserControl.ButtonClickDemo += new EventHandler(Demo1_ButtonClickDemo);
    }
    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        Response.Write("It's working");
    }
