    protected void Page_Load(object sender, EventArgs e)
    {
        Button btnFound = (Button)this.FindControl("myButton");
        if (btnFound != null)
        {
            Response.Write("Found It!");
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Button btn = new Button()
        {
            ID = "myButton",
            Text = "Click Me"
        };
        this.Controls.Add(btn);
    }
