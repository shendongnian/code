    protected void Page_OnInit(object sender, EventArgs e)
    {
        TextBox txt = new TextBox();
        //create more controls
        if (!Page.IsPostBack)
        {
            txt.Text = "initial value";
        }
        Page.Controls.Add(txt);
        //add other controls
    }
